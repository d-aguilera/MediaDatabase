using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MediaDatabase.Hasher
{
    static class Hashing
    {
        public static Task[] CreateHashers(int workers, Context context, int baseWorkerIndex)
        {
            var token = context.AsyncResult.CancellationToken;

            var hashers = new Task[workers];

            for (int i = 0; i < hashers.Length; i++)
            {
                hashers[i] = new Task(() => HashFiles(context, ++baseWorkerIndex), token);
            }

            return hashers;
        }

        static void HashFiles(Context context, int workerId)
        {
            Item item;

            var ar = context.AsyncResult;
            var items = context.Discovered;
            var hashed = context.Hashed;
            var token = ar.CancellationToken;
            var workerStats = ar.WorkerStats;

            try
            {
                while (true)
                {
                    item = Measured.Take(items, token, workerStats, workerId);
                    Hash(item, ar, workerId);
                    Measured.AddToBlockingCollection(hashed, item, token, workerStats, workerId);
                }
            }
            catch (InvalidOperationException) { }
        }

        static void Hash(Item item, ScanAsyncResult ar, int workerId, long maxBufferSize = 10485760L)
        {
            var token = ar.CancellationToken;
            var workerStats = ar.WorkerStats;

            var partial = 0L;
            try
            {
                using (var hasher = MD5.Create())
                using (var stream = Measured.OpenRead(item.FullPath, workerStats, workerId))
                {
                    var buffer = item.Length > maxBufferSize
                        ? new byte[maxBufferSize]
                        : new byte[item.Length]
                        ;

                    var read = stream.Read(buffer, 0, buffer.Length);
                    while (read > 0)
                    {
                        hasher.TransformBlock(buffer, 0, read, null, 0);

                        ar.Hashed.Add(read, 0);
                        partial += read;

                        token.ThrowIfCancellationRequested();

                        read = stream.Read(buffer, 0, buffer.Length);
                    }
                    hasher.TransformFinalBlock(buffer, 0, read);

                    item.Hash = hasher.Hash.ToHex();
                }
            }
            finally
            {
                ar.Hashed.Add(item.Length - partial);
            }
        }
    }
}
