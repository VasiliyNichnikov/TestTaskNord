﻿using Sources.Core.Binder;
using Sources.ViewModel.Counter;
using UnityEngine.UI;

namespace Sources.View.Counter
{
    public class CounterView: Subscriber<CounterViewModel>
    {
        private Text _counterText;
        
        public override void Init(CounterViewModel model)
        {
            base.Init(model);
            SubscribeGameObject(model.GetCounter(), text => _counterText.text = text);
        }

        private void Start()
        {
            _counterText = GetComponent<Text>();
        }
    }
}