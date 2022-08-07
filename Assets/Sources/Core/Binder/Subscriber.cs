using System;
using System.Collections.Generic;
using Sources.Core.Rx;
using UnityEngine;

namespace Sources.Core.Binder
{
    /// <summary>
    /// Позволяет подписывать игровой объект к выбраному обработчику
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Subscriber<T> : MonoBehaviour where T : IDisposable
    {
        protected T ViewModel
        {
            get
            {
                if (_viewModel == null)
                    throw new Exception("ViewModel not passed");
                return _viewModel;
            }
        }
        
        private T _viewModel;
        private readonly List<IDisposable> _propertyHandlers = new List<IDisposable>();

        public virtual void Init(T model)
        {
            _viewModel = model;
        }

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
            var propertyHandler = new EventSubscriber(eventProvider, handler);
            return propertyHandler;
        }

        private void OnDisable()
        {
            ViewModel.Dispose();
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