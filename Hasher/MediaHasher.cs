using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDatabase.Hasher
{
    public static class MediaHasher
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static void Hash(int? scanRequestId, string path, long minSize)
        {
            EndHash(BeginHash(scanRequestId, path, minSize, null, null));
        }

        /// <summary>
        /// Initiates an asynchronous scan process on specified path and its subdirectories in search for media files.
        /// Found media files are hashed and then hashes are stored in the database.
        /// </summary>
        /// <param name="scanRequestId">The scan request identifier, if available.</param>
        /// <param name="path">The directory to scan.</param>
        /// <param name="callback">The method to be called when the asynchronous read operation is completed.</param>
        /// <param name="state">A user-provided object.</param>
        /// <returns>An <see cref="IScanAsyncResult"/> object that allows calling code to monitor and control progress of the async operation.</returns>
        /// <exception cref="ArgumentNullException">Specified <paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException">Specified <paramref name="path"/> does not exist.</exception>
        public static IScanAsyncResult BeginHash(int? scanRequestId, string path, long minSize, AsyncCallback callback, object state)
        {
            if (null == path)
                throw new ArgumentNullException("path");

            if (!Directory.Exists(path))
                throw new ArgumentException("Directory does not exist.", path);

            int volumeId;
            IEnumerable<string> ignoredFolders;
            Discovery.EnsureVolumeForPath(path, out volumeId, out ignoredFolders);

            var now = DateTimeOffset.Now;

            var cts = new CancellationTokenSource();
            var workerStatuses = new Dictionary<WorkerName, TaskStatus>
            {
                { WorkerName.Discovery, TaskStatus.Created },
                { WorkerName.Hashing, TaskStatus.Created },
                { WorkerName.Saving, TaskStatus.Created },
            };

            var ar = new ScanAsyncResult(scanRequestId, path, cts, workerStatuses, state);

            var directories = new BlockingCollection<string>();
            var discovered = new BlockingCollection<Item>();
            var hashed = new BlockingCollection<Item>();

            var context = new Context
            {
                AsyncResult = ar,
                Directories = directories,
                Discovered = discovered,
                Hashed = hashed,
                IgnoredFolders = ignoredFolders,
                VolumeId = volumeId,
                MinSize = minSize,
                Path = path,
            };

            var discoverers = Discovery.CreateDiscoverers(2, context, 0);
            var hashers = Hashing.CreateHashers(1, context, 10);
            var savers = Saving.CreateSavers(1, context, 20);

            //SetupThreadPool(8);

            Task.Run(() =>
            {
                directories.Add(path);

                workerStatuses[WorkerName.Discovery] = TaskStatus.Running;
                ar.DiscoveryStarted = DateTime.Now;
                discoverers.Start();
            })
            .ContinueWith(ant =>
            {
                workerStatuses[WorkerName.Discovery] = WaitForAll(discoverers, cts, ar.Errors);
                directories.CompleteAdding();
                discovered.CompleteAdding();
                ar.DiscoveryFinished = DateTime.Now;
            })
            .ContinueWith(ant =>
            {
                if (workerStatuses[WorkerName.Discovery] != TaskStatus.RanToCompletion)
                    return;

                workerStatuses[WorkerName.Hashing] = TaskStatus.Running;
                ar.HashingStarted = DateTime.Now;
                hashers.Start();
            })
            .ContinueWith(ant =>
            {
                if (workerStatuses[WorkerName.Discovery] != TaskStatus.RanToCompletion)
                    return;

                workerStatuses[WorkerName.Saving] = TaskStatus.Running;
                ar.SavingStarted = DateTime.Now;
                savers.Start();
            })
            .ContinueWith(ant =>
            {
                Task.WaitAll(new[]
                {
                    Task.Run(() =>
                    {
                        workerStatuses[WorkerName.Hashing] = WaitForAll(hashers, cts, ar.Errors);
                        hashed.CompleteAdding();
                        ar.HashingFinished = DateTime.Now;
                    }),
                    Task.Run(() =>
                    {
                        workerStatuses[WorkerName.Saving] = WaitForAll(savers, cts, ar.Errors);
                        ar.SavingFinished = DateTime.Now;
                    })
                });
            })
            .ContinueWith(ant =>
            {
                if (workerStatuses[WorkerName.Saving] != TaskStatus.RanToCompletion)
                    return;

                Saving.PurgeContentFiles(context.VolumeId, context.Path, now);
            })
            .ContinueWith(ant =>
            {
                ar.Finished = DateTime.Now;
                ar.FinishedWaitHandle.Set();
                callback?.Invoke(ar);
            });

            return ar;
        }

        public static void EndHash(IAsyncResult asyncResult)
        {
            if (null == asyncResult)
                throw new ArgumentNullException("asyncResult");

            var awh = asyncResult.AsyncWaitHandle;
            awh.WaitOne();
            awh.Close();
        }

        static TaskStatus WaitForAll(Task[] tasks, CancellationTokenSource cts, ConcurrentQueue<string> errors)
        {
            try
            {
                Task.WaitAll(tasks, cts.Token);
                return TaskStatus.RanToCompletion;
            }
            catch (OperationCanceledException)
            {
                return TaskStatus.Canceled;
            }
            catch (AggregateException ex)
            {
                cts.Cancel();

                errors.Enqueue(ex.InnerExceptions.Select(ie => ie.Message));

                return TaskStatus.Faulted;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        static void SetupThreadPool(int minWorkerThreads)
        {
            int workerThreads, completionPortThreads;
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            ThreadPool.SetMinThreads(workerThreads < minWorkerThreads ? minWorkerThreads : workerThreads, completionPortThreads);
        }
    }
}
