using System;
using System.Threading;

namespace MediaDatabase.Hasher
{
    class Counter : ICounter
    {
        long _bytes;
        long _items;

        public void Add(long bytes)
        {
            Add(bytes, 1L);
        }

        public void Add(ICounter counter)
        {
            Add(counter.Bytes, counter.Items);
        }

        public void Add(long bytes, long items)
        {
            Interlocked.Add(ref _bytes, bytes);
            Interlocked.Add(ref _items, items);
        }

        public long Bytes => Interlocked.Read(ref _bytes);

        public long Items => Interlocked.Read(ref _items);
    }
}
