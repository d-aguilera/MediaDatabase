using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security;
using System.Threading;

namespace MediaDatabase.Hasher
{
    static class Measured
    {
        /// <exception cref="ObjectDisposedException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="InvalidOperationException" />
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public static bool TryTake<T>(BlockingCollection<T> collection, out T item, int millisecondsTimeout, WorkerStats workerStats, int workerId)
        {
            T localItem = default(T);
            try
            {
                return Measure(() => collection.TryTake(out localItem, millisecondsTimeout), workerStats, workerId);
            }
            finally
            {
                item = localItem;
            }
        }

        /// <exception cref="OperationCanceledException" />
        /// <exception cref="ObjectDisposedException" />
        /// <exception cref="InvalidOperationException" />
        public static void AddToBlockingCollection<T>(BlockingCollection<T> collection, T item, CancellationToken token, WorkerStats workerStats, int workerId)
        {
            Measure(() => collection.Add(item, token), workerStats, workerId);
        }

        /// <exception cref="OperationCanceledException" />
        /// <exception cref="ObjectDisposedException" />
        /// <exception cref="InvalidOperationException" />
        public static T Take<T>(BlockingCollection<T> collection, CancellationToken token, WorkerStats workerStats, int workerId)
        {
            return Measure(() => collection.Take(token), workerStats, workerId);
        }

        /// <exception cref="UnauthorizedAccessException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        public static FileStream OpenRead(string path, WorkerStats workerStats, int workerId)
        {
            return Measure(() => new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read), workerStats, workerId);
        }

        public static void Open(IDbConnection conn, WorkerStats workerStats, int workerId)
        {
            Measure(() => conn.Open(), workerStats, workerId);
        }

        public static void Close(IDbConnection conn, WorkerStats workerStats, int workerId)
        {
            Measure(() => conn.Close(), workerStats, workerId);
        }

        /// <exception cref="InvalidOperationException" />
        public static int ExecuteNonQuery(IDbCommand cmd, WorkerStats workerStats, int workerId)
        {
            return Measure(() => cmd.ExecuteNonQuery(), workerStats, workerId);
        }

        static T Measure<T>(Func<T> func, WorkerStats workerStats, int workerId)
        {
            workerStats.Start(workerId);
            try
            {
                return func();
            }
            finally
            {
                workerStats.Stop(workerId);
            }
        }

        static void Measure(Action action, WorkerStats workerStats, int workerId)
        {
            workerStats.Start(workerId);
            try
            {
                action();
            }
            finally
            {
                workerStats.Stop(workerId);
            }
        }
    }
}
