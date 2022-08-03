using System;
using System.Collections.Generic;

namespace Sources.Core.Observer
{
    public class GameObjectObservable: IObservable
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        
        public IDisposable Subscribe(IObserver observer)
        {
            _observers.Add(observer);
            return new GameSubject(observer, _observers);
        }
    }
}