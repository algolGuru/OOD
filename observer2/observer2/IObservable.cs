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
            int countOfObservers = _observers.Count;

            for( int i = 0; i < countOfObservers; i++ )
            {
                if( _observers.Count < countOfObservers )
                {
                    i--;
                    countOfObservers--;
                }

                _observers[ i ].Update( GetChangedData(), this );
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
