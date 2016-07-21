using log4net;

using MediaDatabase.Common;

using System;
using System.Reflection;
using System.ServiceProcess;

namespace MediaDatabase.Service
{
    static class Program
    {
        static readonly ILog __logger = LogManager.GetLogger(typeof(Program));

        static void Main()
        {
            if (Environment.UserInteractive)
            {
                using (var service = new MediaDatabaseService())
                {
                    service.ProgressChanged += (sender, e) => Log(e.Level, e.MessageFunc);

                    service.InvokeNonPublic("OnStart", new[] { new string[0] });

                    Console.WriteLine(Resources.CancelOrStopMessage);

                    ConsoleKeyInfo cki;
                    do
                    {
                        cki = Console.ReadKey(true);

                        if (cki.Key == ConsoleKey.C)
                        {
                            service.InvokeNonPublic("OnCustomCommand", Constants.Service.CancelCommand);
                            Console.WriteLine(Resources.CancelRequested);
                        }
                    }
                    while (cki.Key != ConsoleKey.Enter);

                    Console.WriteLine(Resources.Stopping);

                    service.Stop();
                }
            }
            else
            {
                var services = new[] { new MediaDatabaseService() };
                ServiceBase.Run(services);
            }
        }

        static void Log(LogLevel level, Func<object> messageFunc)
        {
            switch (level)
            {
                case LogLevel.All:
                    break;
                case LogLevel.Verbose:
                    break;
                case LogLevel.Trace:
                    break;
                case LogLevel.Debug:
                    if (__logger.IsDebugEnabled)
                        __logger.Debug(messageFunc());
                    break;
                case LogLevel.Info:
                    if (__logger.IsInfoEnabled)
                        __logger.Info(messageFunc());
                    break;
                case LogLevel.Notice:
                    break;
                case LogLevel.Warn:
                    if (__logger.IsWarnEnabled)
                        __logger.Warn(messageFunc());
                    break;
                case LogLevel.Error:
                    if (__logger.IsErrorEnabled)
                        __logger.Error(messageFunc());
                    break;
                case LogLevel.Severe:
                    break;
                case LogLevel.Critical:
                    break;
                case LogLevel.Alert:
                    break;
                case LogLevel.Fatal:
                    if (__logger.IsFatalEnabled)
                        __logger.Fatal(messageFunc());
                    break;
                case LogLevel.Emergency:
                    break;
                case LogLevel.Off:
                    break;
            }
        }

        static object InvokeNonPublic(this object target, string methodName, params object[] parameters)
        {
            if (null == methodName)
                throw new ArgumentNullException("methodName");

            var mi = target.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            return mi.Invoke(target, parameters);
        }
    }
}
