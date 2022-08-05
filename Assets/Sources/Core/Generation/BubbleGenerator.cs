using System;
using System.Collections.Generic;
using Sources.Core.MySprite;
using UnityEngine;

namespace Sources.Core.Generation
{
    [RequireComponent(typeof(BubbleMaker))]
    public class BubbleGenerator : MonoBehaviour, ICreatedBubble
    {
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
        
        [SerializeField, Header("Минимальное и максимальное кол-во пузырьков")]
        private Range _minNumberOfBubbles;

        [SerializeField] private Range _averageSpeedMultiplication;
        [SerializeField] private Range _rangeSpeed;
        
        
        private BubbleMaker _maker;
        private List<SampleSprite> _createdSprites;

        private void Start()
        {
            _maker = GetComponent<BubbleMaker>();

            Generate();
        }
        
        public BubbleGenerator(BubbleMaker maker)
        {
            _maker = maker;
        }

        public void Unsubscribe(SampleSprite sprite)
        {
            if (_createdSprites == null)
                throw new Exception("Bubbles are not created");
            _createdSprites.Remove(sprite);

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
            _createdSprites = _maker.CreateBubbles(this, 5, 3, 2);
        }
    }
}