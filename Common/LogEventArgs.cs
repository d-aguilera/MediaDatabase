using System;

namespace MediaDatabase.Common
{
    public class LogEventArgs
    {
        public LogEventArgs(LogLevel level, Func<object> messageFunc)
        {
            Level = level;
            MessageFunc = messageFunc;
        }

        public LogLevel Level { get; }

        public Func<object> MessageFunc { get; }
    }
}
