using System;
using System.Collections.Generic;
using Sources.Core.ObjectBubble;
using Sources.Core.UI;
using UnityEngine;

namespace Sources.Core.Generation
{
    [RequireComponent(typeof(BubbleMaker))]
    public class BubbleGenerator : MonoBehaviour, ICreatedBubble
    {
        #region RANGE_CLASS
        [Serializable]
        private class Range
        {
            public int MinValue
            {
                get
                {
                    if (_minValue < 0)
                        _minValue = 0;
                    return _minValue;
                }
            }

            public int MaxValue
            {
                get
                {
                    if (_maxValue < 0)
                        _maxValue = 0;
                    return _maxValue;
                }
            }
            
            [SerializeField] private int _minValue;
            [SerializeField] private int _maxValue;
        }
        #endregion

        [SerializeField] private CounterUI _counter;
        
        [SerializeField, Header("Минимальное и максимальное кол-во пузырьков")]
        private Range _numberOfBubbles;
        
        [SerializeField] private Range _averageSpeedMultiplication;
        [SerializeField] private Range _rangeSpeed;

        [SerializeField, Header("Номер волны после которого будет повышаться сложность игры")]
        private int _numberOfWaveOfIncreasingDifficulty;

        private int _waveNumber;
        private BubbleMaker _maker;
        private List<SampleBubble> _createdSprites;

        private int _currentNumberOfBubbles;
        private float _currentAverageSpeedMultiplication;
        private float _currentRangeSpeed;
        
        private void Start()
        {
            _maker = GetComponent<BubbleMaker>();
            
            _waveNumber = 1;
            _currentNumberOfBubbles = _numberOfBubbles.MinValue;
            _currentAverageSpeedMultiplication = _averageSpeedMultiplication.MinValue;
            _currentRangeSpeed = _rangeSpeed.MinValue;
            
            Generate();
        }
        
        public BubbleGenerator(BubbleMaker maker)
        {
            _maker = maker;
        }

        public void Unsubscribe(SampleBubble bubble)
        {
            if (_createdSprites == null)
                throw new Exception("Bubbles are not created");
            _createdSprites.Remove(bubble);
            _counter.Router.UpdateCounter((int)(_maker.MaxSizeBubble / bubble.GetSize().x));

            if (CheckGeneration())
            {
                Generate();
            }
        }

        private bool CheckGeneration()
        {
            return _createdSprites.Count == 0;
        }

        private void Generate()
        {
            _createdSprites = _maker.CreateBubbles(this, _currentNumberOfBubbles, _currentAverageSpeedMultiplication, _currentRangeSpeed);
            IncreaseDifficulty();
        }
        
        /// <summary>
        /// Производит усложнение игры
        /// </summary>
        private void IncreaseDifficulty()
        {
            if (_waveNumber % _numberOfWaveOfIncreasingDifficulty == 0)
            {
                _currentNumberOfBubbles += 1;
                _currentAverageSpeedMultiplication += 0.5f;
                _currentRangeSpeed += 0.5f;
                CheckCorrectnessOfValues();
            }
            _waveNumber++;
        }

        private void CheckCorrectnessOfValues()
        {
            if (_currentNumberOfBubbles > _numberOfBubbles.MaxValue)
                _currentNumberOfBubbles = _numberOfBubbles.MaxValue;
        }
    }
}