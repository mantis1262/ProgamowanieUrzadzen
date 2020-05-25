using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Observer
{
    public class DiscountCreator : IObservable<DiscountEvent>
    {
        private IList<IObserver<DiscountEvent>> observers;

        public DiscountCreator()
        {
            observers = new List<IObserver<DiscountEvent>>();
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

        public void Discount(DiscountEvent discount)
        {
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
