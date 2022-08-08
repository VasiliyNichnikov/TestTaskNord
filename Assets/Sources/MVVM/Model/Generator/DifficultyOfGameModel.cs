using Sources.Core.RangeValues;

namespace Sources.MVVM.Model.Generator
{
    public class DifficultyOfGameModel : BaseModel
    {
        public int CurrentNumberOfBubbles
        {
            get
            {
                return _numberOfBubbles.CurrentValue;
            }
        }

        public float CurrentSpeedUpOn
        {
            get
            {
                return _speedOnUp.CurrentValue;
            }
        }

        private readonly RangeValueWithStepInt _numberOfBubbles;
        private readonly RangeValueWithStepFloat _speedOnUp;
        private int _currentWave;

        private readonly int _durationOfOneDifficultly;

        public DifficultyOfGameModel(int durationOfOneDifficultly, RangeValueWithStepInt numberOfBubbles, RangeValueWithStepFloat speedUpOn)
        {
            _currentWave = 1;
            _durationOfOneDifficultly = durationOfOneDifficultly;
            _numberOfBubbles = numberOfBubbles.Init();
            _speedOnUp = speedUpOn.Init();
        }

        /// <summary>
        /// Проверяет, нужно усложнять игру или нет, и если нужно, усложняет
        /// </summary>
        public void CheckDifficulty()
        {
            if (_currentWave % _durationOfOneDifficultly == 0)
            {
                _numberOfBubbles.AddStep();
                _speedOnUp.AddStep();
            }

            ModelChanged();
            _currentWave++;
        }
    }
}