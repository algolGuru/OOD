using System.Collections.Generic;

namespace observer
{
    public interface IObservable<T>
    {
        void RegisterObserver( IObserver<T> observer );
        string NotifyObservers();
        void RemoveObserver( IObserver<T> observer );
    }

    public abstract class Observer<T> : IObservable<T>
    {
        public int ObserverNumber { get; }

        public Observer( int objectName )
        {
            ObserverNumber = objectName;
        }

        public string NotifyObservers()
        {
            var result = "";
            foreach( var observer in _observers )
            {
                result += observer.Update( GetChangedData(), this );
            }

            return result;
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
