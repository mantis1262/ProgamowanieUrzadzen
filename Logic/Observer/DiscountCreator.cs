using Logic.Dto;
using Logic.Interfaces;
using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Observer
{
    public class DiscountCreator : IObservable<DiscountEvent>
    {
        private Random _rnd = new Random();
        private IList<IObserver<DiscountEvent>> observers;
        private IMerchandiseService _merchandiseService;

        public DiscountCreator(IMerchandiseService merchandiseService)
        {
            observers = new List<IObserver<DiscountEvent>>();
            _merchandiseService = merchandiseService;
        }

        public IDisposable Subscribe(IObserver<DiscountEvent> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
        }

        public class Unsubscriber : IDisposable
        {
            private IList<IObserver<DiscountEvent>> _observers;
            private IObserver<DiscountEvent> _observer;
            private bool _disposed = false;

            public Unsubscriber(IList<IObserver<DiscountEvent>> observers, IObserver<DiscountEvent> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                {
                    return;
                }

                if (disposing)
                {
                    if (_observer != null && _observers.Contains(_observer))
                    {
                        _observers.Remove(_observer);
                    }
                }
                _disposed = true;
            }
        }

        public async void Discount(double maxDiscount)
        {
            double discountValue = _rnd.NextDouble() * maxDiscount;
            List<MerchandiseDto> merchandises = (await _merchandiseService.GetMerchandises()).ToList();

            foreach (MerchandiseDto merchandise in merchandises)
            {
                merchandise.NettoPrice -= merchandise.NettoPrice * discountValue;
            }

            DiscountEvent discount = new DiscountEvent(discountValue, merchandises);

            foreach (IObserver<DiscountEvent> observer in observers)
            {
                if (discount == null)
                {
                    observer.OnError(new ArgumentNullException());
                }
                observer.OnNext(discount);
            }
        }

        public void End()
        {
            foreach (IObserver<DiscountEvent> observer in observers.ToArray())
            {
                observer.OnCompleted();
            }
            observers.Clear();
        }
    }
}
