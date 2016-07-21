using MediaDatabase.Common;
using MediaDatabase.Database;
using MediaDatabase.Database.Entities;
using MediaDatabase.Hasher;
using MediaDatabase.Service.SignalR;

using Microsoft.Owin.Hosting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDatabase.Service
{
    public partial class MediaDatabaseService : ServiceBase
    {
        #region Main thread

        ServiceStateMachine _sm;
        IDisposable _signalr;

        #region Service event handlers

        protected override void OnStart(string[] args)
        {
            _sm = new ServiceStateMachine();
            _sm.Starting += OnStarting;
            _sm.Waiting += OnWaiting;
            _sm.Running += OnRunning;
            _sm.Stopping += OnStopping;
            _sm.Start();
        }

        protected override void OnStop()
        {
            _sm.Stop();

            DisposeManaged();

            OnProgressChanged(LogLevel.Info, () => Resources.ServiceStopped);
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

            switch (command)
            {
                case Constants.Service.CancelCommand:
                    _sm.Cancel();
                    break;
            }
        }

        #endregion

        #region IDisposable

        bool _disposed;

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                DisposeManaged();
            }

            _disposed = true;

            base.Dispose(disposing);
        }

        void DisposeManaged()
        {
            Dispose(ref _sm);
            Dispose(ref _signalr);
            Dispose(ref components);
        }

        void Dispose<T>(ref T obj) where T : class, IDisposable
        {
            if (null == obj) return;
            try { obj.Dispose(); }
            catch { }
            finally { obj = null; }
        }

        void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("Service has been disposed of already.");
        }

        #endregion

        #endregion

        #region ProgressChanged event

        public event EventHandler<LogEventArgs> ProgressChanged;

        string Format(string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }

        void OnProgressChanged(LogLevel level, Func<object> messageFunc)
        {
            ProgressChanged?.Invoke(this, new LogEventArgs(level, messageFunc));
        }

        #endregion

        #region Background thread

        #region State machine event handlers

        void OnStarting(object source, EventArgs e)
        {
            _signalr = WebApp.Start(Constants.Service.SignalRServerUrl);

            OnProgressChanged(LogLevel.Info, () => Format(Resources.SignalRRunningFormat, Constants.Service.SignalRServerUrl));

            OnProgressChanged(LogLevel.Info, () => Resources.ServiceStarted);
        }

        void OnWaiting(object source, EventArgs e)
        {
            _sm.StopRequested.WaitOne(Constants.Service.Delay);
        }

        void OnRunning(object source, EventArgs e)
        {
            try
            {
                int? id;

                using (var context = new DataGateway())
                {
                    id = context.DequeueScanRequestId();
                }

                if (id.HasValue)
                {
                    OnProgressChanged(LogLevel.Info, () => Format(Resources.DequeuedRequestFormat, id));
                    BeginScan(id.Value);
                }
            }
            catch (Exception ex)
            {
                OnProgressChanged(LogLevel.Error, () =>
                {
                    var list = new List<Exception>();
                    for (var o = ex; o != null; o = o.InnerException)
                        list.Add(o);
                    return string.Join(" <-- ", list.Select(o => o.Message));
                });
                try
                {
                    EventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
                }
                catch { }
            }
        }

        void OnStopping(object source, EventArgs e)
        {
            MyHub.DisconnectAllClients(5000);
        }

        #endregion

        #region BeginScan

        void BeginScan(int scanRequestId)
        {
            BeginScan(GetScanRequestById(scanRequestId));
        }

        static ScanRequest GetScanRequestById(int id)
        {
            using (var context = new DataGateway())
            {
                return context.Set<ScanRequest>().Single(o => o.Id == id);
            }
        }

        void BeginScan(ScanRequest scanRequest)
        {
            OnProgressChanged(LogLevel.Info, () => Format(Resources.VolumeScanBeginningFormat, scanRequest.VolumeName));

            var status = TaskStatus.RanToCompletion;
            try
            {
                var ar = MediaHasher.BeginHash(scanRequest.Id, scanRequest.VolumeName, 1048576, null, null);
                try
                {
                    MyHub.ScanAsyncResult = ar;

                    var handles = new[] { ar.AsyncWaitHandle, _sm.CancelRequested, _sm.StopRequested };

                    var canceled = WaitHandle.WaitAny(handles) > 0;

                    if (canceled)
                    {
                        ar.Cancel();
                        ar.AsyncWaitHandle.WaitOne();
                    }
                }
                finally
                {
                    MediaHasher.EndHash(ar);

                    status = ar.OverallStatus;

                    MyHub.ScanAsyncResult = new ScanAsyncResultSnapshot(ar);
                }
            }
            catch (Exception)
            {
                status = TaskStatus.Faulted;
                throw;
            }
            finally
            {
                using (var context = new DataGateway())
                {
                    scanRequest.Status = (int)status;
                    context.Update(scanRequest);
                }

                OnProgressChanged(LogLevel.Info, () => Format(Resources.VolumeScanFinishedFormat, scanRequest.VolumeName));
            }
        }

        #endregion

        #endregion
    }
}
