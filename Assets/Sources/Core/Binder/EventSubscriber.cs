using System;
using Sources.Core.Rx;

namespace Sources.Core.Binder
{
    public class EventSubscriber: IDisposable
    {
        private readonly IEventProvider _eventProvider;
        private readonly Action _handler;
        
        public EventSubscriber(IEventProvider eventProvider, Action handler)
        {
            _eventProvider = eventProvider;
            _handler = handler;
            _eventProvider.OnChanged += _handler;
        }

        public void Dispose()
        {
            _eventProvider.OnChanged -= _handler;
        }
    }
}