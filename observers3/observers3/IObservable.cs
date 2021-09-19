using System;
using System.Collections.Generic;

namespace observer
{
    public class Subscriber<T> : IComparable<Subscriber<T>>
    {
        public Subscriber( int priority, IObserver<T> observer )
        {
            Priority = priority;
            Observer = observer;
        }

        public int Priority { get; }
        public IObserver<T> Observer { get; }

        public int CompareTo( Subscriber<T> other )
        {
            if( Priority > other.Priority )
            {
                return -1;
            }
            else if( Priority < other.Priority )
            {
                return 1;
            }

            return 0;
        }
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
            foreach( var subscriber in _subsctibers )
            {
                subscriber.Observer.Update( GetChangedData() );
            }
        }

        protected abstract T GetChangedData();

        public void RegisterObserver( Subscriber<T> observer )
        {
            _subsctibers.Add( observer );
            _subsctibers.Sort();
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
    }
}
