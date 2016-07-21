using System;

namespace MediaDatabase.Hasher
{
    public interface ICounter
    {
        /// <summary>
        /// Gets the number of bytes accumulated by the counter.
        /// </summary>
        long Bytes
        {
            get;
        }

        /// <summary>
        /// Gets the number of items accumulated by the counter.
        /// </summary>
        long Items
        {
            get;
        }
    }
}
