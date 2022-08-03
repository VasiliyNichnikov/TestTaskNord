using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Core.Observer
{
    public class ObservableGameObject: IObservable
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        
        public IDisposable Subscribe(IObserver observer)
        {
            MonoBehaviour.print("Добавление к наблюдателю");
            _observers.Add(observer);
            return new Subject(observer, _observers);
        }
    }
}