using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Cors;
using Owin;

using System;

using MediaDatabase.Hasher;
using System.Threading.Tasks;
using System.Threading;

namespace MediaDatabase.Service.SignalR
{
    static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

    [CLSCompliant(false)]
    public class MyHub : Hub
    {
        public static IScanAsyncResult ScanAsyncResult
        {
            get;
            internal set;
        }

        internal static MyHub Instance
        {
            get;
            private set;
        }

        public MyHub()
        {
            Instance = this;
        }

        [HubMethodName("getScanAsyncResult")]
        public IScanAsyncResult RetrieveScanAsyncResult()
        {
            return ScanAsyncResult;
        }

        #region Connection management

        static int __connections;
        static ManualResetEvent __idle = new ManualResetEvent(true);

        internal static bool DisconnectAllClients(int millisecondsTimeout)
        {
            Instance?.Clients.All.disconnect();

            return __idle.WaitOne(millisecondsTimeout);
        }

        public override Task OnConnected()
        {
            if (Interlocked.Increment(ref __connections) > 0)
                __idle.Reset();

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (Interlocked.Decrement(ref __connections) <= 0)
                __idle.Set();

            return base.OnDisconnected(stopCalled);
        }

        #endregion
    }
}
