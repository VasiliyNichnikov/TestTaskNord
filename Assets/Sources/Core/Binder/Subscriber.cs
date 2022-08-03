using System;
using System.Collections.Generic;
using Sources.Core.Rx;
using UnityEngine;

namespace Sources.Core.Binder
{
    public abstract class Subscriber<T> : MonoBehaviour
    {
        private readonly List<IDisposable> _propertyHandlers = new List<IDisposable>();

        public abstract void Init(T model);
        
        public void SubscribeGameObject<TProperty>(IReactiveProperty<TProperty> property, Action<TProperty> handler)
        {
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
            foreach (var propertyHandler in _propertyHandlers)
            {
                propertyHandler.Dispose();
            }
        }
    }
}