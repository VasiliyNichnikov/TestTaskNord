using System;
using UnityEngine;

namespace Sources.Core.RangeValues
{
    [Serializable]
    public class RangeValueWithStepFloat
    {
        public float CurrentValue { get; private set; }

        [SerializeField]
        private float _minValue;
        [SerializeField]
        private float _maxValue;
        [SerializeField]
        private float _step;
        
        private bool _isInitialized;

        public RangeValueWithStepFloat Init()
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