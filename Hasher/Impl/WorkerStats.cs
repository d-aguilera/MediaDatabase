using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MediaDatabase.Hasher
{
    public class WorkerStats : IWorkerStats
    {
        WorkerInfo[] _stats = new[]
        {
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
            new WorkerInfo(),
        };

        public void Start(int workerId)
        {
            _stats[workerId].StopWatch.Start();
        }

        public void Stop(int workerId)
        {
            _stats[workerId].StopWatch.Stop();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void Finish(int workerId)
        {
            _stats[workerId].Finished = DateTime.Now;
        }

        public DateTime? Finished(int workerId)
        {
            return _stats[workerId].Finished;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public long ElapsedTicks(int workerId)
        {
            return _stats[workerId].StopWatch.ElapsedTicks;
        }

        public long ElapsedMilliseconds(int workerId)
        {
            return _stats[workerId].StopWatch.ElapsedMilliseconds;
        }
    }

    class WorkerInfo
    {
        public WorkerInfo()
        {
            StopWatch = new Stopwatch();
        }

        public Stopwatch StopWatch
        {
            get;
            private set;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public DateTime? Finished
        {
            get;
            set;
        }
    }
}
