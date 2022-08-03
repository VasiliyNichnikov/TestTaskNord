using System;
using Sources.Core.Rx;

namespace Sources.Core.Observer
{
    public class ObserverGameObject: IObserver
    {
        private readonly IEventProvider _eventProvider;
        private readonly Action _handler;
        
        public ObserverGameObject(IEventProvider eventProvider, Action handler)
        {
            _eventProvider = eventProvider;
            _handler = handler;
        }

        public void SubscribeToHandler()
        {
            _eventProvider.OnChanged += _handler;
        }

        public void UnsubscribeToHandler()
        {
            _eventProvider.OnChanged -= _handler;
        }
    }
}