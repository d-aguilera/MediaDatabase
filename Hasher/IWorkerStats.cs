using System;

namespace MediaDatabase.Hasher
{
    public interface IWorkerStats
    {
        DateTime? Finished(int workerId);

        long ElapsedTicks(int workerId);

        long ElapsedMilliseconds(int workerId);
    }
}
