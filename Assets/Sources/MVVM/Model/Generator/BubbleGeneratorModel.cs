using System;
using System.Collections.Generic;
using Sources.Core.Bubble;
using Sources.Core.Generator;
using Sources.MVVM.View.Generator;
using UnityEngine;

namespace Sources.MVVM.Model.Generator
{
    public class BubbleGeneratorModel: BaseModel, ICreatedBubble
    {
        private readonly BubbleMaker _maker;
        
        private List<SampleBubble> _createdSprites = new List<SampleBubble>();

        public BubbleGeneratorModel(BubbleMaker maker)
        {
            _maker = maker;
        }
        
        public void Unsubscribe(SampleBubble bubble)
        {
            if (_createdSprites == null)
                throw new Exception("Bubbles are not created");
            _createdSprites.Remove(bubble);
            // _counter.Router.UpdateCounter((int)(_maker.MaxSizeBubble / bubble.GetSize().x));

            if (CheckGeneration())
            {
                Generate();
            }
        }

        public void StartGeneration()
        {
            Generate();
        }
        
        private bool CheckGeneration()
        {
            return _createdSprites.Count == 0;
        }

        private void Generate()
        {
            // todo нужно поменять передаваемые данные 
            _createdSprites = _maker.CreateBubbles(this, 2, 2);
            ModelChanged();
        }

        // private void Generate()
        // {
        //     _createdSprites = _maker.CreateBubbles(this, _currentNumberOfBubbles, _currentAverageSpeedMultiplication, _currentRangeSpeed);
        //     // IncreaseDifficulty();
        // }
    }
}