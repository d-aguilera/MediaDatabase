using MediaDatabase.Database;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDatabase.Hasher
{
    static class Saving
    {
        public static Task[] CreateSavers(int workers, Context context, int baseWorkerIndex)
        {
            var token = context.AsyncResult.CancellationToken;

            var savers = new Task[workers];

            for (int i = 0; i < savers.Length; i++)
            {
                savers[i] = new Task(() => SaveHashes(context, ++baseWorkerIndex), token);
            }

            return savers;
        }

        static void SaveHashes(Context context, int workerId)
        {
            var ar = context.AsyncResult;
            var hashed = context.Hashed;
            var volumeId = context.VolumeId;
            var token = ar.CancellationToken;
            var workerStats = ar.WorkerStats;

            token.ThrowIfCancellationRequested();

            using (var gateway = new DataGateway())
            using (var cmd = gateway.CreateCommand(CommandType.StoredProcedure, "spContentFileSaveExBulk"))
            using (var dt = CreateBatchDataTable())
            {
                var pData = cmd.CreateParameter();
                pData.ParameterName = "@data";
                pData.Direction = ParameterDirection.Input;
                pData.Value = dt;
                pData.GetType().GetProperty("SqlDbType")?.SetValue(pData, SqlDbType.Structured);
                cmd.Parameters.Add(pData);

                try
                {
                    while (true)
                    {
                        var batch = TakeBatchFromBlockingCollection(hashed, token, workerStats, workerId);

                        var counter = FillBatchDataTable(dt, batch, volumeId);

                        Measured.Open(cmd.Connection, workerStats, workerId);
                        try
                        {
                            Measured.ExecuteNonQuery(cmd, workerStats, workerId);
                        }
                        catch (Exception ex)
                        {
                            ar.Errors.Enqueue(ex.Message);
                            throw;
                        }
                        finally
                        {
                            ar.Saved.Add(counter);

                            Measured.Close(cmd.Connection, workerStats, workerId);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    // don't throw if queue completed
                }
            }
        }

        public static void PurgeContentFiles(int volumeId, string path, DateTimeOffset lastUpdatedBefore)
        {
            using (var gateway = new DataGateway())
            {
                gateway.PurgeContentFiles(volumeId, path, lastUpdatedBefore);
            }
        }

        static DataTable CreateBatchDataTable()
        {
            var dt = new DataTable();
            try
            {
                dt.Locale = CultureInfo.InvariantCulture;

                var columns = dt.Columns;
                columns.Add("VolumeId", typeof(int));
                var cPath = columns.Add("Path", typeof(string));
                cPath.MaxLength = 1024;
                var cName = columns.Add("Name", typeof(string));
                cName.MaxLength = 256;
                var cCreationTimeUtc = columns.Add("CreationTimeUtc", typeof(DateTime));
                cCreationTimeUtc.DateTimeMode = DataSetDateTime.Utc;
                var cLastWriteTimeUtc = columns.Add("LastWriteTimeUtc", typeof(DateTime));
                cLastWriteTimeUtc.DateTimeMode = DataSetDateTime.Utc;
                var cContentType = columns.Add("ContentType", typeof(string));
                cContentType.MaxLength = 128;
                var cHash = columns.Add("Hash", typeof(string));
                cHash.MaxLength = 32;

                return dt;
            }
            catch
            {
                dt.Dispose();
                throw;
            }
        }

        static ICounter FillBatchDataTable(DataTable dt, IEnumerable<Item> batch, int volumeId)
        {
            var columns = dt.Columns;
            var volumeIdColumn = columns["VolumeId"];
            var pathColumn = columns["Path"];
            var nameColumn = columns["Name"];
            var creationTimeUtcColumn = columns["CreationTimeUtc"];
            var lastWriteTimeUtcColumn = columns["LastWriteTimeUtc"];
            var hashColumn = columns["Hash"];
            var contentTypeColumn = columns["ContentType"];

            var counter = new Counter();

            dt.Clear();
            dt.BeginLoadData();
            foreach (var item in batch)
            {
                var row = dt.NewRow();
                row.SetField(volumeIdColumn, volumeId);
                row.SetField(pathColumn, item.PathNoRoot);
                row.SetField(nameColumn, item.Name);
                row.SetField(creationTimeUtcColumn, item.CreationTimeUtc);
                row.SetField(lastWriteTimeUtcColumn, item.LastWriteTimeUtc);
                row.SetField(hashColumn, item.Hash);
                row.SetField(contentTypeColumn, item.ContentType);

                dt.Rows.Add(row);

                counter.Add(item.Length);
            }
            dt.EndLoadData();

            return counter;
        }

        static IEnumerable<T> TakeBatchFromBlockingCollection<T>(BlockingCollection<T> collection, CancellationToken token, WorkerStats workerStats, int workerId, int maxBatchSize = 500)
        {
            var batch = new T[maxBatchSize];
            var count = 0;
            var item = Measured.Take(collection, token, workerStats, workerId);
            do
            {
                batch[count++] = item;
                token.ThrowIfCancellationRequested();
            }
            while (count < maxBatchSize && collection.TryTake(out item, 0));
            return batch.Take(count);
        }
    }
}
