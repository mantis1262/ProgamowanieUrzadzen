﻿using Logic.Observer;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Logic.Services
{
    public class CyclicDiscountService : IDisposable
    {
        public DiscountCreator Provider;

        Random _rnd = new Random();
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
            double randomNumber = _rnd.NextDouble() * MaxDiscount;
            Provider.Discount(new DiscountEvent(randomNumber));
        }

        public void Dispose()
        {
            if (_timerSubscription != null)
                _timerSubscription.Dispose();
        }
    }
}
