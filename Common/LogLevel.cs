using System;

namespace MediaDatabase.Common
{
    public enum LogLevel
    {
        All = -2147483648,
        Verbose = 10000,
        Trace = 20000,
        Debug = 30000,
        Info = 40000,
        Notice = 50000,
        Warn = 60000,
        Error = 70000,
        Severe = 80000,
        Critical = 90000,
        Alert = 100000,
        Fatal = 110000,
        Emergency = 120000,
        Off = 2147483647,
    }
}
