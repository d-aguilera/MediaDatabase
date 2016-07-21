using MediaDatabase.Hasher;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace MediaDatabase.Service
{
    class ScanAsyncResultSnapshot : IScanAsyncResult
    {
        public ScanAsyncResultSnapshot(IScanAsyncResult ar)
        {
            CompletedSynchronously = ar.CompletedSynchronously;
            Discovered = new Counter(ar.Discovered);
            DiscoveryFinished = ar.DiscoveryFinished;
            DiscoveryStarted = ar.DiscoveryStarted;
            DiscoveryStatus = ar.DiscoveryStatus;
            Errors = ar.Errors.ToArray();
            Finished = ar.Finished;
            Hashed = new Counter(ar.Hashed);
            HashingFinished = ar.HashingFinished;
            HashingProgress = ar.HashingProgress;
            HashingStarted = ar.HashingStarted;
            HashingStatus = ar.HashingStatus;
            IsCompleted = ar.IsCompleted;
            OverallStatus = ar.OverallStatus;
            Path = ar.Path;
            Saved = new Counter(ar.Saved);
            SavingFinished = ar.SavingFinished;
            SavingProgress = ar.SavingProgress;
            SavingStarted = ar.SavingStarted;
            SavingStatus = ar.SavingStatus;
            Scanned = new Counter(ar.Scanned);
            ScanRequestId = ar.ScanRequestId;
            Started = ar.Started;
            Warnings = ar.Warnings.ToArray();
        }

        public object AsyncState => null;

        public WaitHandle AsyncWaitHandle => null;

        public bool CompletedSynchronously { get; }

        public ICounter Discovered { get; }

        public DateTime? DiscoveryFinished { get; }

        public DateTime? DiscoveryStarted { get; }

        public TaskStatus DiscoveryStatus { get; }

        public IEnumerable<string> Errors { get; }

        public DateTime? Finished { get; }

        public ICounter Hashed { get; }

        public DateTime? HashingFinished { get; }

        public int HashingProgress { get; }

        public DateTime? HashingStarted { get; }

        public TaskStatus HashingStatus { get; }

        public bool IsCompleted { get; }

        public TaskStatus OverallStatus { get; }

        public string Path { get; }

        public ICounter Saved { get; }

        public DateTime? SavingFinished { get; }

        public int SavingProgress { get; }

        public DateTime? SavingStarted { get; }

        public TaskStatus SavingStatus { get; }

        public ICounter Scanned { get; }

        public int? ScanRequestId { get; }

        public DateTime Started { get; }

        public IEnumerable<string> Warnings { get; }

        public IWorkerStats WorkerStats => null;

        public void Cancel()
        {
        }
    }

    class Counter : ICounter
    {
        public Counter(ICounter counter)
        {
            Bytes = counter.Bytes;
            Items = counter.Items;
        }

        public long Bytes { get; }

        public long Items { get; }
    }
}
