using System;
using Sources.Core.Utils;
using Random = UnityEngine.Random;

namespace Sources.Core.Generator
{
    public class CalculatorSizeBubble
    {
        public int[] BubbleSizes { get; private set; }
        public int NumberOfBubbles
        {
            get
            {
                return _numberOfBubbles;
            }
            set
            {
                if (value > 0)
                {
                    BubbleSizes = new int[value];
                    _lengthOfBubbleSizes = 0.0f;
                    _numberOfBubbles = value;
                }
                else
                    throw new Exception("The number of bubbles created must be greater than 0");
            }
        }

        public float SpaceBetweenBubbles
        {
            get
            {
                return (_maxLengthForBubbles - _lengthOfBubbleSizes) / (_numberOfBubbles - 1);
            }
        }
        
        private int _numberOfBubbles;
        
        private float _lengthOfBubbleSizes;
        private readonly int _minSizeBubble;
        private readonly int _maxSizeBubble;
        private readonly int _maxLengthForBubbles;
        
        public CalculatorSizeBubble(int minSizeBubble, int maxSizeCamera)
        {
            _minSizeBubble = minSizeBubble;
            _maxSizeBubble = maxSizeCamera;
            NumberOfBubbles = 1;
            _maxLengthForBubbles = ScreenSettings.WidthScreen - ScreenSettings.BorderOnRight - ScreenSettings.BorderOnLeft;
        }
        
        
        public void Calculate()
        {
            for (var index = 0; index < _numberOfBubbles; index++)
            {
                var sizeBubble = GetSizeBubble();
                if (_lengthOfBubbleSizes + sizeBubble >= _maxLengthForBubbles)
                {
                    _numberOfBubbles = index;
                    break;
                }

                BubbleSizes[index] = sizeBubble;
                _lengthOfBubbleSizes += sizeBubble;
            }
        }

        private int GetSizeBubble()
        {
            return Random.Range(_minSizeBubble, _maxSizeBubble);
        }
    }
}