using MediaDatabase.Hasher;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDatabase.TestConsole
{
    static class Monitoring
    {
        public static void Start(IScanAsyncResult ar, int refreshMillis = 250)
        {
            Console.Write(Resources.PressAnyKeyToCancel);

            var left = Console.CursorLeft;
            var top = Console.CursorTop;

            while (!ar.AsyncWaitHandle.WaitOne(refreshMillis))
            {
                ShowProgress(left, top, ar);

                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    Console.SetCursorPosition(0, top);
                    Console.Write(new string(' ', Resources.PressAnyKeyToCancel.Length));
                    Console.SetCursorPosition(0, top);
                    Console.Write(Resources.Canceling);
                    ar.Cancel();
                }
            }

            var lines = ShowProgress(left, top, ar);

            // Erase current line
            Console.SetCursorPosition(0, top);
            Console.Write(new string(Chars.Space, Console.BufferWidth));
            // Go down to the end
            Console.Write(new string(Chars.LineFeed, lines));
        }

        #region ShowProgress

        static int ShowProgress(int left, int top, IScanAsyncResult ar)
        {
            var now = DateTime.Now;
            var elapsed = now - ar.Started;
            var lines = 0;

            var sb = new StringBuilder();

            lines += ShowProgressAddHeader(sb, ar, now);

            if (elapsed.TotalMilliseconds > 0.0)
            {
                lines += ShowProgressAddWorkerStats(sb, ar, now);
            }

            lines += ShowProgressAddErrorsAndWarnings(sb, ar);

            var currentLeft = Console.CursorLeft;
            var currentTop = Console.CursorTop;

            Console.SetCursorPosition(left, top);
            Console.Write(sb.ToString());
            Console.SetCursorPosition(currentLeft, currentTop);

            return lines;
        }

        static int ShowProgressAddHeader(StringBuilder sb, IScanAsyncResult ar, DateTime now)
        {
            var elapsed = now - ar.Started;
            var spinPhase = (int)elapsed.TotalSeconds % 4;
            var lines = 0;

            sb.AppendLine();
            sb.AppendLine();

            lines += ShowProgressAddBar(sb, 50, ar.HashingProgress);

            sb.AppendLine();

            lines += ShowProgressAddWorkerProgress(sb, "Scanned", ar.DiscoveryStatus, ar.Scanned, ar.DiscoveryStarted, ar.DiscoveryFinished ?? now, spinPhase);
            lines += ShowProgressAddWorkerProgress(sb, "Discovered", ar.DiscoveryStatus, ar.Discovered, ar.DiscoveryStarted, ar.DiscoveryFinished ?? now, spinPhase);
            lines += ShowProgressAddWorkerProgress(sb, "Hashed", ar.HashingStatus, ar.Hashed, ar.HashingStarted, ar.HashingFinished ?? now, spinPhase);
            lines += ShowProgressAddWorkerProgress(sb, "Saved", ar.SavingStatus, ar.Saved, ar.SavingStarted, ar.SavingFinished ?? now, spinPhase);

            sb.AppendLine();

            sb.Append("Elapsed: ");
            sb.Append(elapsed);
            sb.AppendLine();

            return lines + 5;
        }

        static int ShowProgressAddBar(StringBuilder sb, int barLength, int progress)
        {
            var doneLength = (progress * barLength) / 100;

            sb.Append("[");
            sb.Append(Chars.FullBlock, doneLength);
            sb.AppendFormat(" {0,-4}", progress + "%");
            sb.Append(Chars.Space, barLength - doneLength);
            sb.Append("]");
            sb.AppendLine();

            return 1;
        }

        static int ShowProgressAddWorkerProgress(StringBuilder sb, string taskTitle, TaskStatus taskStatus, ICounter counter, DateTime? started, DateTime finished, int spinPhase)
        {
            var items = counter.Items;
            var bytes = counter.Bytes;

            double num;
            string unit;

            FormatBytes(bytes, out num, out unit);
            sb.AppendFormat(
                CultureInfo.InvariantCulture,
                "[{2}] {3,-11} {0,6} files | {1,7:0.00} {4}",
                items,
                num,
                TaskStatusSymbol(taskStatus, spinPhase),
                taskTitle + ":",
                unit
                );

            var elapsed = finished - started;

            if (elapsed.HasValue)
            {
                var totalSeconds = (long)elapsed.Value.TotalSeconds;
                if (totalSeconds > 0L)
                {
                    FormatBytes(bytes / totalSeconds, out num, out unit);
                    sb.AppendFormat(
                        CultureInfo.InvariantCulture,
                        " | {0,5} fps | {1,7:0.00} {2}/s",
                        items / totalSeconds,
                        num,
                        unit
                        );
                }
            }

            sb.AppendLine();

            return 1;
        }

        static void FormatBytes(long bytes, out double num, out string unit)
        {
            if (bytes == 0L)
            {
                num = 0;
                unit = "B";
                return;
            }

            var a = (double)bytes;
            var b = Math.Log(a, 2);
            var c = (int)Math.Floor(b / 10.0);

            //num = Math.Floor(a / Math.Pow(2, c * 10));
            //num = Math.Floor((10.0 * a) / Math.Pow(2, c * 10)) / 10.0;
            num = a / Math.Pow(2, c * 10);
            unit = c == 0 ? "B" : " KMGT"[c] + "B";
        }

        static int ShowProgressAddWorkerStats(StringBuilder sb, IScanAsyncResult ar, DateTime now)
        {
            var lines = 0;
            var width = Console.BufferWidth;
            var workerStats = ar.WorkerStats;

            sb.AppendLine();
            for (int i = 0; i < 24; i++)
            {
                var wms = workerStats.ElapsedMilliseconds(i);
                if (wms > 0L)
                {
                    var wems = (long)((workerStats.Finished(i) ?? now) - ar.Started).TotalMilliseconds;
                    var wp = (100L * wms) / wems;
                    var length = NumberWidth(i) + NumberWidth(wms) + NumberWidth(wp) + 4;
                    var filler = width - length;
                    sb.Append(i);
                    sb.Append("> ");
                    sb.Append(wms);
                    sb.Append(Chars.Space);
                    sb.Append(wp);
                    sb.Append("%");
                    sb.Append(Chars.Space, filler);
                    lines++;
                }
            }

            return lines + 1;
        }

        static int ShowProgressAddErrorsAndWarnings(StringBuilder sb, IScanAsyncResult ar)
        {
            return 0
                + AddProducerConsumerCollection(sb, ar.Errors, int.MaxValue)
                + AddProducerConsumerCollection(sb, ar.Warnings, 15)
                ;
        }

        static int AddProducerConsumerCollection(StringBuilder sb, IEnumerable<string> items, int maxLines)
        {
            var lines = 0;
            var width = Console.BufferWidth;

            if (maxLines > 0)
            {
                var snap = items.ToArray();
                var count = snap.Count();
                if (count > 0)
                {
                    sb.Append(new string(Chars.Space, width)); lines++;

                    var top = snap.Take(maxLines);
                    foreach (var item in top)
                    {
                        var length = NumberWidth(count) + 2 + item.Length;
                        var filler = width - (length % width);
                        sb.Append(count);
                        sb.Append("> ");
                        sb.Append(item);
                        sb.Append(Chars.Space, filler);

                        lines += length / width + 1;
                        count--;
                        if (--maxLines < 1)
                            break;
                    }
                }
            }

            return lines;
        }

        static int NumberWidth(long number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("number", "Number cannot be negative.");

            if (number == 0)
                return 1;

            return (int)(Math.Floor(Math.Log10(number))) + 1;
        }

        static string TaskStatusSymbol(TaskStatus status, int spinPhase)
        {
            switch (status)
            {
                case TaskStatus.Created:
                    switch (spinPhase % 4)
                    {
                        case 0:
                        case 2:
                            return Chars.Space.ToString();
                        default:
                            return Chars.MiddleDot.ToString();
                    }

                case TaskStatus.RanToCompletion:
                    return Chars.SquareRoot.ToString();

                case TaskStatus.Canceled:
                    return Chars.Minus.ToString();

                case TaskStatus.Faulted:
                    return Chars.Cross.ToString();

                default:
                    return @"-\|/"[spinPhase % 4].ToString();
            }
        }

        #endregion
    }
}
