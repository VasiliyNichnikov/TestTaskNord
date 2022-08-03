using System;
using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.Model;
using UnityEngine;

namespace Sources.ViewModel
{
    // Нужно наследоваться от интерфейса IDisposable для очистки мусора
    public class BubbleMovementViewModel: IVMUpdate, IDisposable
    {
        public IReactiveProperty<Vector3> BubblePosition
        {
            get
            {
                return _bubblePosition;
            }
        }

        private readonly ReactiveProperty<Vector3> _bubblePosition = new ReactiveProperty<Vector3>();
        private readonly BubbleMovementModel _model;

        public BubbleMovementViewModel(BubbleMovementModel model)
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

        public void Update()
        {
            _model.Move();
        }

        /// <summary>
        /// Действия, которые происходят при изменении модели
        /// </summary>
        private void OnChanged()
        {
            _bubblePosition.Value = _model.BubblePosition;
        }
    }
}

