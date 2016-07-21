using System;

using MediaDatabase.Hasher;

namespace MediaDatabase.TestConsole
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AsyncScanTest();
        }

        static void AsyncScanTest()
        {
            var ar = MediaHasher.BeginHash(null, @"C:\", 1048576, null, null); // Users\Daniel\Videos
            try
            {
                Monitoring.Start(ar);
            }
            finally
            {
                MediaHasher.EndHash(ar);
            }
        }
    }
}
