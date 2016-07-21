using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDatabase.Hasher
{
    class ScanAsyncResult : IScanAsyncResult
    {
        IDictionary<WorkerName, TaskStatus> _workerStatuses;

        public ScanAsyncResult(int? scanRequestId, string path, CancellationTokenSource cancellationTokenSource, IDictionary<WorkerName, TaskStatus> workerStatuses, object state)
        {
            if (null == path)
                throw new ArgumentNullException("path");

            if (null == cancellationTokenSource)
                throw new ArgumentNullException("cancellationTokenSource");

            if (null == workerStatuses)
                throw new ArgumentNullException("workerStatuses");

            _workerStatuses = workerStatuses;

            AsyncState = state;
            ScanRequestId = scanRequestId;
            Path = path;
            CancellationTokenSource = cancellationTokenSource;
            Discovered = new Counter();
            Errors = new ConcurrentQueue<string>();
            FinishedWaitHandle = new ManualResetEvent(false);
            Hashed = new Counter();
            Saved = new Counter();
            Scanned = new Counter();
            Started = DateTime.Now;
            Warnings = new ConcurrentStack<string>();
            WorkerStats = new WorkerStats();
        }

        internal ManualResetEvent FinishedWaitHandle
        {
            get;
            private set;
        }

        #region IAsyncResult

        public object AsyncState
        {
            get;
            private set;
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                return FinishedWaitHandle;
            }
        }

        public bool CompletedSynchronously => false;

        public bool IsCompleted => Finished.HasValue;

        #endregion

        #region IScanAsyncResult

        ICounter IScanAsyncResult.Discovered => Discovered;
        IEnumerable<string> IScanAsyncResult.Errors => Errors;
        ICounter IScanAsyncResult.Hashed => Hashed;
        ICounter IScanAsyncResult.Saved => Saved;
        ICounter IScanAsyncResult.Scanned => Scanned;
        IEnumerable<string> IScanAsyncResult.Warnings => Warnings;
        IWorkerStats IScanAsyncResult.WorkerStats => WorkerStats;

        #endregion

        public int? ScanRequestId
        {
            get;
            private set;
        }

        public string Path
        {
            get;
            private set;
        }

        CancellationTokenSource CancellationTokenSource
        {
            get;
            set;
        }

        public CancellationToken CancellationToken => CancellationTokenSource.Token;

        public DateTime Started
        {
            get;
            set;
        }

        public DateTime? Finished
        {
            get;
            set;
        }

        public Counter Scanned
        {
            get;
            private set;
        }

        public DateTime? DiscoveryFinished
        {
            get;
            set;
        }

        public DateTime? DiscoveryStarted
        {
            get;
            set;
        }

        public TaskStatus DiscoveryStatus => _workerStatuses[WorkerName.Discovery];

        public Counter Discovered
        {
            get;
            private set;
        }

        public DateTime? HashingFinished
        {
            get;
            set;
        }

        public DateTime? HashingStarted
        {
            get;
            set;
        }

        public TaskStatus HashingStatus => _workerStatuses[WorkerName.Hashing];

        public Counter Hashed
        {
            get;
            private set;
        }

        public int HashingProgress => CalculateProgress(Discovered.Bytes, Hashed.Bytes);

        public DateTime? SavingFinished
        {
            get;
            set;
        }

        public DateTime? SavingStarted
        {
            get;
            set;
        }

        public TaskStatus SavingStatus => _workerStatuses[WorkerName.Saving];

        public Counter Saved
        {
            get;
            private set;
        }

        public int SavingProgress => CalculateProgress(Discovered.Items, Saved.Items);

        public ConcurrentStack<string> Warnings
        {
            get;
            private set;
        }

        public ConcurrentQueue<string> Errors
        {
            get;
            private set;
        }

        public WorkerStats WorkerStats
        {
            get;
            private set;
        }

        public TaskStatus OverallStatus
        {
            get
            {
                var statuses = new[] { DiscoveryStatus, HashingStatus, SavingStatus };

                if (statuses.Any(status => status == TaskStatus.Faulted))
                    return TaskStatus.Faulted;

                if (statuses.Any(status => status == TaskStatus.Canceled))
                    return TaskStatus.Canceled;

                if (statuses.All(status => status == TaskStatus.RanToCompletion))
                    return TaskStatus.RanToCompletion;

                return TaskStatus.Running;
            }
        }

        public void Cancel()
        {
            CancellationTokenSource.Cancel();
        }

        static int CalculateProgress(long produced, long consumed)
        {
            if (produced == 0L)
                return 0;

            if (consumed > produced)
                return 100;

            var num = Convert.ToDouble((100L * consumed));
            var denom = Convert.ToDouble(produced);
            return Convert.ToInt32(Math.Floor(num / denom));
        }
    }
}
