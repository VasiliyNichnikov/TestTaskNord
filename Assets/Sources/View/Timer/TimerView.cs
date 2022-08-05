using System;
using Sources.Core.Binder;
using Sources.ViewModel.Timer;
using UnityEngine.UI;

namespace Sources.View.Timer
{
    public class TimerView: Subscriber<TimerViewModel>
    {
        private Text _timerText;
        
        public override void Init(TimerViewModel model)
        {
            base.Init(model);
            SubscribeGameObject(ViewModel.GetTimeInSeconds(), text => _timerText.text = text);
        }

        private void Awake()
        {
            _timerText = GetComponent<Text>();
        }

        private void Update()
        {
            ViewModel.UpdateTime();
        }
    }
}