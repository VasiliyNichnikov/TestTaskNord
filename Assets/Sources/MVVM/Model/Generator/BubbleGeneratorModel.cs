using System;
using System.Collections.Generic;
using Sources.Core.Bubble;
using Sources.Core.Generator;
using Sources.Routers.Counter;
using Sources.Routers.Generator;

namespace Sources.MVVM.Model.Generator
{
    public class BubbleGeneratorModel: BaseModel, ICreatedBubble
    {
        private readonly BubbleMaker _maker;
        private readonly ICounterRouter _counterRouter;
        private readonly IDifficultyOfGameRouter _difficultyOfGameRouter;
        
        private List<SampleBubble> _createdSprites = new List<SampleBubble>();
        

        public BubbleGeneratorModel(BubbleMaker maker, IDifficultyOfGameRouter difficultyOfGameRouter)
        {
            _maker = maker;
            _difficultyOfGameRouter = difficultyOfGameRouter;
        }
        
        public void Unsubscribe(SampleBubble bubble)
        {
            if (_createdSprites == null)
                throw new Exception("Bubbles are not created");
            _createdSprites.Remove(bubble);
            // todo нужно добавить очки
            // _counterRouter.UpdateCounter((int)(_maker.MaxSizeBubble / bubble.GetSize().x));

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
            var calculatorSpeed = new CalculatorSpeedBubble(_difficultyOfGameRouter.CurrentSpeedUpOn);
            _createdSprites =
                _maker.CreateBubbles(_difficultyOfGameRouter.CurrentNumberOfBubbles, this, calculatorSpeed);
            _difficultyOfGameRouter.CheckDifficulty();
            ModelChanged();
        }
    }
}