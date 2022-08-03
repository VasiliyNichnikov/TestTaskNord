using System;
using System.Collections.Generic;
using Sources.Core.Rx;
using UnityEngine;

namespace Sources.Core.Binder
{
    public abstract class Subscriber : MonoBehaviour
    {
        private List<IDisposable> _propertyHandlers = new List<IDisposable>();
        
        public void Subscribe<T>(IReactiveProperty<T> property, Action<T> handler)
        {
            print("Подписка на событие");
            var propertyHandler = SubscribeInternal(
                property,
                () => handler(property.Value)
            );
            _propertyHandlers.Add(propertyHandler);
        }

        private IDisposable SubscribeInternal(IEventProvider eventProvider,
            Action handler)
        {
            var propertyHandler = Pool.Get(eventProvider, handler);
            return propertyHandler;
        }

        private void OnDestroy()
        {
            print("OnDestroy");
            foreach (var propertyHandler in _propertyHandlers)
            {
                propertyHandler.Dispose();
            }
        }
    }
}