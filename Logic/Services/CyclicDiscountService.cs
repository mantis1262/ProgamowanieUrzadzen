using Logic.Events;
using Logic.Interfaces;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Logic.Services
{
    public class CyclicDiscountService : IDisposable
    {
        Random _rnd = new Random();
        private IDisposable _timerSubscription = null;

        public double MaxDiscount { get; private set; }

        public TimeSpan Period { get; private set; }

        public event EventHandler<DiscountEvent> Handler = delegate { };

        public CyclicDiscountService(double maxDiscount, TimeSpan period)
        {
            MaxDiscount = maxDiscount;
            Period = period;
        }

        public void Start()
        {
            IObservable<long> _TimerObservable = Observable.Interval(Period);
            _timerSubscription = _TimerObservable.ObserveOn(Scheduler.Default).Subscribe(c => GiveDiscount());
        }

        private void GiveDiscount()
        {
            double randomNumber = _rnd.NextDouble() * MaxDiscount;
            Handler?.Invoke(this, new DiscountEvent(randomNumber));
        }

        public void Dispose()
        {
            if (_timerSubscription != null)
                _timerSubscription.Dispose();
        }
    }
}
