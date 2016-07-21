using MediaDatabase.Database;
using MediaDatabase.Database.Entities;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace MediaDatabase.Hasher
{
    static class Discovery
    {
        public static Task[] CreateDiscoverers(int workers, Context context, int baseWorkerIndex)
        {
            var token = context.AsyncResult.CancellationToken;

            var discoverers = new Task[workers];

            for (int i = 0; i < discoverers.Length; i++)
            {
                discoverers[i] = new Task(() => DiscoverFiles(context, ++baseWorkerIndex), token);
            }

            return discoverers;
        }

        static void DiscoverFiles(Context context, int workerId)
        {
            var ar = context.AsyncResult;
            var directories = context.Directories;
            var token = ar.CancellationToken;
            var workerStats = ar.WorkerStats;

            string dir = null;

            while (Measured.TryTake(directories, out dir, 250, workerStats, workerId))
            {
                token.ThrowIfCancellationRequested();

                if (context.IgnoredFolders.Any(dir2 => IsSameOrParentDirectory(dir2, dir)))
                    continue;

                AddSubEntries(dir, context, workerId);
            }
        }

        public static void EnsureVolumeForPath(string path, out int volumeId, out IEnumerable<string> ignoredFolders)
        {
            string mediumCaption;
            long mediumSize;
            string mediumSerialNumber;
            string mediumTypeName;
            string partitionCaption;
            int partitionDiskIndex;
            int partitionIndex;
            string volumeCaption;
            string volumeFileSystem;
            string volumeName;
            string volumeSerialNumber;

            WmiHelpers.GetVolumeInfo(path,
                out mediumCaption,
                out mediumSize,
                out mediumSerialNumber,
                out mediumTypeName,
                out partitionCaption,
                out partitionDiskIndex,
                out partitionIndex,
                out volumeCaption,
                out volumeFileSystem,
                out volumeName,
                out volumeSerialNumber
                );

            using (var context = new DataGateway())
            {
                var vid = context.EnsureVolume(
                    mediumCaption,
                    mediumSize,
                    mediumSerialNumber,
                    mediumTypeName,
                    partitionCaption,
                    partitionDiskIndex,
                    partitionIndex,
                    volumeCaption,
                    volumeFileSystem,
                    volumeName,
                    volumeSerialNumber
                    );

                ignoredFolders = context.Set<IgnoredFolder>()
                    .Where(f => f.Volume.Id == vid)
                    .Select(f => f.Path)
                    .ToArray()
                    ;

                volumeId = vid;
            }
        }

        static bool IsSameOrParentDirectory(string test, string dir)
        {
            /*
            var testNoRoot = Path.IsPathRooted(test) ? test.Substring(Path.GetPathRoot(test).Length) : test;
            var dirNoRoot = Path.IsPathRooted(dir) ? dir.Substring(Path.GetPathRoot(dir).Length) : dir;
            */
            var compare = string.Compare(dir, test, StringComparison.OrdinalIgnoreCase);
            if (compare < 0)
                return false;
            if (compare == 0)
                return true;
            return dir.StartsWith(test + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase);
        }

        static void AddSubEntries(string dir, Context context, int workerId)
        {
            var ar = context.AsyncResult;
            var directories = context.Directories;
            var token = ar.CancellationToken;
            var workerStats = ar.WorkerStats;

            var entries = HandleWarnings(() => Directory.EnumerateFileSystemEntries(dir), ar.Warnings);

            if (null == entries)
                return;

            foreach (var entry in entries)
            {
                token.ThrowIfCancellationRequested();

                if (File.Exists(entry))
                    AddFile(entry, context, workerId);

                else if (Directory.Exists(entry))
                    Measured.AddToBlockingCollection(directories, entry, token, workerStats, workerId);
            }
        }

        static void AddFile(string file, Context context, int workerId)
        {
            var ar = context.AsyncResult;
            var warnings = ar.Warnings;

            var fi = HandleWarnings(() => new FileInfo(file), warnings);

            if (null == fi)
                return;

            var length = HandleWarnings(() => fi.Length, warnings);

            if (length == 0L || length < context.MinSize)
                return;

            ar.Scanned.Add(length);

            string contentType;
            if (!IsMediaFile(file, out contentType))
                return;

            Measured.AddToBlockingCollection(context.Discovered, Item.Create(fi, contentType), ar.CancellationToken, ar.WorkerStats, workerId);

            ar.Discovered.Add(length);
        }

        static bool IsMediaFile(string file, out string contentType)
        {
            var extension = Path.GetExtension(file);

            if (null == extension)
            {
                contentType = null;
                return false;
            }

            switch (extension.ToUpperInvariant())
            {
                case ".AVI":
                    contentType = "video/avi";
                    return true;
                case ".JPG":
                    contentType = "image/jpeg";
                    return true;
                case ".PNG":
                    contentType = "image/png";
                    return true;
                case ".MP4":
                    contentType = "video/mp4";
                    return true;
                default:
                    contentType = null;
                    return false;
            }
        }

        static T HandleWarnings<T>(Func<T> func, ConcurrentStack<string> warnings)
        {
            try
            {
                return func();
            }
            catch (DirectoryNotFoundException ex)
            {
                warnings.Push(ex.Message);
                return default(T);
            }
            catch (IOException ex)
            {
                warnings.Push(ex.Message);
                return default(T);
            }
            catch (SecurityException ex)
            {
                warnings.Push(ex.Message);
                return default(T);
            }
            catch (UnauthorizedAccessException ex)
            {
                warnings.Push(ex.Message);
                return default(T);
            }
        }
    }
}
