using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MediaDatabase.Hasher
{
    class Context
    {
        public ScanAsyncResult AsyncResult
        {
            get;
            set;
        }

        public BlockingCollection<string> Directories
        {
            get;
            set;
        }

        public BlockingCollection<Item> Discovered
        {
            get;
            set;
        }

        public BlockingCollection<Item> Hashed
        {
            get;
            set;
        }

        public IEnumerable<string> IgnoredFolders
        {
            get;
            set;
        }

        public int VolumeId
        {
            get;
            set;
        }

        public long MinSize
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }
    }
}
