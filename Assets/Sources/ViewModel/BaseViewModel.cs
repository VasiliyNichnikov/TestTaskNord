using System;
using Sources.Model;

namespace Sources.ViewModel
{
    public abstract class BaseViewModel<T> : IDisposable where T : BaseModel
    {
        protected readonly T Model;

        protected BaseViewModel(T model)
        {
            Model = model;
            // Подписаться на изменения
            Model.Subscribe(OnChanged);
        }

        public void Dispose()
        {
            // Отписка от изменений
            Model.Unsubscribe(OnChanged);
        }

        /// <summary>
        /// Действия, которые происходят при изменении модели
        /// </summary>
        protected abstract void OnChanged();
    }
}