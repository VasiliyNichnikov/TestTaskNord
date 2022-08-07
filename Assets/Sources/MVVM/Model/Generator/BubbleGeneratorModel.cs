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
        

        public BubbleGeneratorModel(BubbleMaker maker, ICounterRouter counterRouter, IDifficultyOfGameRouter difficultyOfGameRouter)
        {
            _maker = maker;
            _counterRouter = counterRouter;
            _difficultyOfGameRouter = difficultyOfGameRouter;
        }
        
        public void Unsubscribe(SampleBubble bubble, int numberScore)
        {
            if (_createdSprites == null)
                throw new Exception("Bubbles are not created");
            _createdSprites.Remove(bubble);
            // todo нужно добавить очки
            _counterRouter.UpdateCounter(numberScore);

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