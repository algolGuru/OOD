using System.Collections.Generic;

namespace observer
{
    public class Subscriber<T>
    {
        public Subscriber( int priority, IObserver<T> observer )
        {
            Priority = priority;
            Observer = observer;
        }

        public int Priority { get; }
        public IObserver<T> Observer { get; }
    }

    public interface IObservable<T>
    {
        void RegisterObserver( Subscriber<T> observer );
        void NotifyObservers();
        void RemoveObserver( Subscriber<T> observer );
    }

    public abstract class Observer<T> : IObservable<T>
    {
        public void NotifyObservers()
        {
            foreach ( var subscriber in _subsctibers )
            {
                subscriber.Observer.Update( GetChangedData() );
            }
        }

        protected abstract T GetChangedData();

        public void RegisterObserver( Subscriber<T> observer )
        {
            InsertSubscriber( observer );
        }

        public void RemoveObserver( Subscriber<T> observer )
        {
            _subsctibers.Remove( observer );
        }

        public List<Subscriber<T>> GetSubscribers()
        {
            return _subsctibers;
        }

        private readonly List<Subscriber<T>> _subsctibers = new List<Subscriber<T>>();

        private void InsertSubscriber( Subscriber<T> subscriber )
        {
            for ( int i = 0 ; i < _subsctibers.Capacity ; i++ )
            {
                if ( subscriber.Priority >= _subsctibers[i].Priority )
                {
                    _subsctibers.Insert( i, subscriber );
                    return;
                }
            }

            _subsctibers.Add( subscriber );
        }
    }
}
