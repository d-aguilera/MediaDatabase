using System;
using System.IO;

namespace MediaDatabase.Hasher
{
    class Item
    {
        public static Item Create(FileInfo fi, string contentType)
        {
            return new Item()
            {
                Path = fi.DirectoryName,
                Name = fi.Name,
                CreationTimeUtc = fi.CreationTimeUtc,
                LastWriteTimeUtc = fi.LastWriteTimeUtc,
                Length = fi.Length,
                ContentType = contentType
            };
        }

        public string ContentType
        {
            get;
            private set;
        }

        public DateTime CreationTimeUtc
        {
            get;
            private set;
        }

        public string FullPath => System.IO.Path.Combine(Path, Name);

        public string Hash
        {
            get;
            set;
        }

        public DateTime LastWriteTimeUtc
        {
            get;
            private set;
        }

        public long Length
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Path
        {
            get;
            private set;
        }

        public string PathNoRoot
        {
            get
            {
                var path = Path;
                var root = System.IO.Path.GetPathRoot(path);
                return string.IsNullOrEmpty(root)
                    ? path
                    : path.Substring(root.Length)
                    ;
            }
        }
    }
}
