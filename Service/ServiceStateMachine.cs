using Stateless;

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDatabase.Service
{
    enum State { Stopped, Starting, Waiting, Running, Stopping };
    enum Event { StartRequested, StartupFinished, WaitTimedOut, RunFinished, StopRequested, StoppingFinished };

    class ServiceStateMachine : StateMachine<State, Event>, IDisposable
    {
        public ServiceStateMachine() : base(State.Stopped)
        {
            Configure(State.Stopped)
                .Permit(Event.StartRequested, State.Starting)
                ;

            Configure(State.Starting)
                .OnEntry(OnStarting)
                .Permit(Event.StartupFinished, State.Waiting)
                ;

            Configure(State.Waiting)
                .OnEntry(OnWaiting)
                .Permit(Event.WaitTimedOut, State.Running)
                .Permit(Event.StopRequested, State.Stopping)
                ;

            Configure(State.Running)
                .OnEntry(OnRunning)
                .Permit(Event.RunFinished, State.Waiting)
                ;

            Configure(State.Stopping)
                .OnEntry(OnStopping)
                .OnExit(OnStopped)
                .Permit(Event.StoppingFinished, State.Stopped)
                ;

            _stopRequested = new ManualResetEvent(false);
            _cancelRequested = new AutoResetEvent(false);
            _queue = new BlockingCollection<Event>();
            _cts = new CancellationTokenSource();
            _queueStarted = new ManualResetEvent(false);
            _backgroundTask = Task.Run(() => QueueCallback(), _cts.Token);

            // don't leave until background task has started
            _queueStarted.WaitOne();
        }

        #region External events

        ManualResetEvent _stopRequested;
        AutoResetEvent _cancelRequested;

        public WaitHandle StopRequested => _stopRequested;
        public WaitHandle CancelRequested => _cancelRequested;

        public void Start()
        {
            QueueEvent(Event.StartRequested);
        }

        public void Cancel()
        {
            _cancelRequested.Set();
        }

        public void Stop()
        {
            _stopRequested.Set();

            AwaitBackgroundTask();
        }

        #endregion

        #region Internal events

        public event EventHandler<EventArgs> Starting;
        public event EventHandler<EventArgs> Waiting;
        public event EventHandler<EventArgs> Running;
        public event EventHandler<EventArgs> Stopping;

        protected virtual void OnStarting()
        {
            InvokeHandler(Starting, Event.StartupFinished);
        }

        protected virtual void OnWaiting()
        {
            InvokeHandler(Waiting, () => _stopRequested.WaitOne(0) ? Event.StopRequested : Event.WaitTimedOut);
        }

        protected virtual void OnRunning()
        {
            InvokeHandler(Running, Event.RunFinished);
        }

        protected virtual void OnStopping()
        {
            InvokeHandler(Stopping, Event.StoppingFinished);
        }

        protected virtual void OnStopped()
        {
            _cts.Cancel();
        }

        void InvokeHandler(EventHandler<EventArgs> handler, Func<Event> onExit)
        {
            InvokeHandler(handler, onExit());
        }

        void InvokeHandler(EventHandler<EventArgs> handler, Event onExit)
        {
            try
            {
                handler?.Invoke(this, new EventArgs());
            }
            finally
            {
                QueueEvent(onExit);
            }
        }

        #endregion

        #region Event queue management

        BlockingCollection<Event> _queue;
        CancellationTokenSource _cts;
        ManualResetEvent _queueStarted;
        Task _backgroundTask;

        void QueueEvent(Event trigger)
        {
            _queue.Add(trigger);
        }

        void QueueCallback()
        {
            _queueStarted.Set();

            while (true)
            {
                Fire(_queue.Take(_cts.Token));
            }
        }

        void AwaitBackgroundTask()
        {
            try
            {
                _backgroundTask?.Wait();
            }
            catch (AggregateException)
            {
            }
        }

        #endregion

        #region IDisposable

        bool _disposed;

        public void Dispose()
        {
            if (_disposed)
                return;

            Dispose(ref _backgroundTask);
            Dispose(ref _cts);
            Dispose(ref _queue);
            Dispose(ref _queueStarted);
            Dispose(ref _stopRequested);
            Dispose(ref _cancelRequested);

            _disposed = true;
        }

        void Dispose<T>(ref T obj) where T : IDisposable
        {
            if (null == obj) return;
            try { obj.Dispose(); }
            catch { }
            finally { obj = default(T); }
        }

        void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("State machine has been disposed of already.");
        }

        #endregion
    }
}
