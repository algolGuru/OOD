using System.Collections.Generic;

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
            foreach( var observer in _observers )
            {
                observer.Update( GetChangedData() );
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
