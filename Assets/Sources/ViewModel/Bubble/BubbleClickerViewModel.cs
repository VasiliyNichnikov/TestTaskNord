﻿using System.Collections;
using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.Model.Bubble;
using UnityEngine;


namespace Sources.ViewModel.Bubble
{
    public class BubbleClickerViewModel : BaseViewModel<BubbleClickerModel>
    {
        private readonly ReactiveProperty<Vector3> _bubbleScale = new ReactiveProperty<Vector3>();

        public BubbleClickerViewModel(BubbleClickerModel model) : base(model)
        {
        }

        public IEnumerator ClickOnBubble()
        {
            return Model.Change();
        }

        protected override void OnChanged()
        {
            _bubbleScale.Value = Model.BubbleScale;
        }

        public IReactiveProperty<Vector3> GetScale()
        {
            return _bubbleScale;
        }
    }
}