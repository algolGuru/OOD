using System.Collections.Generic;
using System.Linq;

namespace observer
{
    public interface IObservable<T>
    {
        void RegisterObserver( IObserver<T> observer );
        void NotifyObservers();
        void RemoveObserver( IObserver<T> observer );
    }

    public abstract class Observer<T> : IObservable<T>
    {
        public void NotifyObservers()
        {
            List<IObserver<T>> _observersCopy = _observers.ToList();
            foreach( var item in _observersCopy )
            {
                item.Update( GetChangedData(), this );
            }
        }

        protected abstract T GetChangedData();

        public void RegisterObserver( IObserver<T> observer )
        {
            _observers.Add( observer );
        }

        public void RemoveObserver( IObserver<T> observer )
        {
            _observers.Remove( observer );
        }

        private List<IObserver<T>> _observers = new List<IObserver<T>>();
    }
}
