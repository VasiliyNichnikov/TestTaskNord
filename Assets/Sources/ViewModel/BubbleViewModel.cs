using System;
using Sources.Core.Rx;
using UnityEngine;
using Sources.Infrastructure;
using Sources.Model;

namespace Sources.ViewModel
{
    // Нужно наследоваться от интерфейса IDisposable для очистки мусора
    public class BubbleViewModel: IDisposable
    {
        private BubbleModel _model;
        // Выносим только те значения, которые нужно менять в View из Model
        private readonly ReactiveProperty<Sprite> _value = new ReactiveProperty<Sprite>();

        public BubbleViewModel(BubbleModel model)
        {
            _model = model;
            // Подписаться на изменения
            _model.Changed += OnChanged;
        }
        
        public void Dispose()
        {
            _model.Changed -= OnChanged;
        }
        
        private void OnChanged()
        {
            _value.Value = _model.Sprite;
        }
        
        public IReactiveProperty<Sprite> GetSprite()
        {
            return _value;
        }
    }
}

