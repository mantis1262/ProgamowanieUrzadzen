using Logic.Events;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Logic.Services
{
    public class CyclicActionService : IDisposable
    {
        private IDisposable m_TimerSubscription = null;
        private bool disposedValue = false;

        public TimeSpan Period { get; private set; }

        public event EventHandler<CyclicEvent> Tick;

        public CyclicActionService(TimeSpan period)
        {
            Period = period;
        }

        public void Start()
        {
            IObservable<long> _TimerObservable = Observable.Interval(Period);
            m_TimerSubscription = _TimerObservable.ObserveOn(Scheduler.Default).Subscribe(c => RaiseTick(c));
        }

        private void RaiseTick(long counter)
        {
            Tick?.Invoke(this, new CyclicEvent(counter));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
