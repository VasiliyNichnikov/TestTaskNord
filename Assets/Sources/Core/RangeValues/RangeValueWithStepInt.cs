using System;
using UnityEngine;

namespace Sources.Core.RangeValues
{
    [Serializable]
    public class RangeValueWithStepInt
    {
        public int CurrentValue { get; private set; }
        
        [SerializeField]
        private int _minValue;
        [SerializeField]
        private int _maxValue;
        [SerializeField]
        private int _step;

        private bool _isInitialized;

        public RangeValueWithStepInt Init()
        {
            if (_isInitialized == false)
            {
                CurrentValue = _minValue;
                _isInitialized = true;
            }

            return this;
        }
        
        public void AddStep()
        {
            if (CurrentValue + _step <= _maxValue)
                CurrentValue += _step;
        }
    }
}