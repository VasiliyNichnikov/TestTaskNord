﻿using System;
using System.Collections.Generic;

namespace Sources.Core.Observer
{
    public class Subject: IDisposable
    {
        private readonly List<IObserver> _observers;
        private readonly IObserver _observer;
        private bool _disposed;

        public Subject(IObserver observer, List<IObserver> observers)
        {
            _observer = observer;
            _observers = observers;
        }
        
        public void Dispose()
        {
            if (_disposed == false)
            {
                _observer.UnsubscribeToHandler();
                _observers.Remove(_observer);
                _disposed = true;
            }
        }
    }
}