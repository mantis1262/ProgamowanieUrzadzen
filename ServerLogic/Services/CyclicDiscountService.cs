using ServerLogic.Observer;
using ServerLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace ServerLogic.Services
{
    public class CyclicDiscountService : IDisposable
    {
        public DiscountCreator Provider;

        private IDisposable _timerSubscription = null;

        public double MaxDiscount { get; private set; }

        public TimeSpan Period { get; private set; }

        public CyclicDiscountService(double maxDiscount, TimeSpan period, DiscountCreator discountCreator)
        {
            MaxDiscount = maxDiscount;
            Period = period;
            Provider = discountCreator;
        }

        public void Start()
        {
            IObservable<long> _TimerObservable = Observable.Interval(Period);
            _timerSubscription = _TimerObservable.ObserveOn(Scheduler.Default).Subscribe(c => GiveDiscount());
        }

        private void GiveDiscount()
        {
            Provider.Discount(MaxDiscount);
        }

        public void Dispose()
        {
            if (_timerSubscription != null)
                _timerSubscription.Dispose();
        }
    }
}
