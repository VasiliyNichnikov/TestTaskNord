using System;
using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.Model;
using UnityEngine;

namespace Sources.ViewModel
{
    public class BubbleClickerViewModel: IVMOnMouseDown, IDisposable
    {
        public IReactiveProperty<Sprite> BubbleSprite
        {
            get
            {
                return _bubbleSprite;
            }
        }

        private readonly ReactiveProperty<Sprite> _bubbleSprite = new ReactiveProperty<Sprite>();
        private readonly BubbleClickerModel _model;

        public BubbleClickerViewModel(BubbleClickerModel model)
        {
            _model = model;
            // Подписаться на изменения
            _model.Changed += OnChanged;
        }
        
        public void Dispose()
        {
            MonoBehaviour.print("Отписка от событий viewModel");
            _model.Changed -= OnChanged;
        }
        
        public void OnMouseDown()
        {
            _model.ClickOnBubble();
        }
        
        
        /// <summary>
        /// Действия, которые происходят при изменении модели
        /// </summary>
        private void OnChanged()
        {
            _bubbleSprite.Value = _model.Sprite;
        }
    }
}