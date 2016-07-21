using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaDatabase.Common
{
    public static class Helpers
    {
        public static string CompactPath(string longPathName, int wantedLength)
        {
            if (wantedLength > 32767)
                throw new ArgumentOutOfRangeException("wantedLength", wantedLength, "Value too high.");

            var sb = new StringBuilder(wantedLength + 1);
            SafeNativeMethods.PathCompactPathEx(sb, longPathName, wantedLength + 1, 0);
            return sb.ToString();
        }

        public static Tuple<double, string> FormatBytes(long bytes)
        {
            if (bytes == 0L)
            {
                return Tuple.Create(0.0, "B");
            }

            var a = (double)bytes;
            var b = Math.Log(a, 2);
            var c = (int)Math.Floor(b / 10.0);

            //num = Math.Floor(a / Math.Pow(2, c * 10));
            //num = Math.Floor((10.0 * a) / Math.Pow(2, c * 10)) / 10.0;
            var number = a / Math.Pow(2, c * 10);
            var unit = c == 0 ? "B" : " KMGT"[c] + "B";

            return Tuple.Create(number, unit);
        }
    }
}