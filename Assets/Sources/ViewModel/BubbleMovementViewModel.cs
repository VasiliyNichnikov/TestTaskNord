﻿using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.Model;
using UnityEngine;

namespace Sources.ViewModel
{
    public class BubbleMovementViewModel : BaseViewModel<BubbleMovementModel>, IVMUpdate
    {
        public IReactiveProperty<Vector3> BubblePosition
        {
            get { return _bubblePosition; }
        }

        private readonly ReactiveProperty<Vector3> _bubblePosition = new ReactiveProperty<Vector3>();

        public BubbleMovementViewModel(BubbleMovementModel model) : base(model)
        {
        }

        public void Update()
        {
            Model.Change();
        }

        protected override void OnChanged()
        {
            _bubblePosition.Value = Model.BubblePosition;
        }
    }
}