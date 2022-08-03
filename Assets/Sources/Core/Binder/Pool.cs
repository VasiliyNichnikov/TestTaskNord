using System;
using Sources.Core.Observer;
using Sources.Core.Rx;

namespace Sources.Core.Binder
{
    public static class Pool
    {
        private static readonly IObservable _observable;

        static Pool()
        {
            _observable = new ObservableGameObject();
        }
        
        public static IDisposable Get(IEventProvider eventProvider, Action handler)
        {
            IObserver observer = new ObserverGameObject(eventProvider, handler);
            observer.SubscribeToHandler();
            
            return _observable.Subscribe(observer);
        }
    }
}