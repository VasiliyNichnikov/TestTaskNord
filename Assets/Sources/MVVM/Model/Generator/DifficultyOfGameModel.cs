using UnityEngine;

namespace Sources.MVVM.Model.Generator
{
    public class DifficultyOfGameModel : BaseModel
    {
        public int CurrentNumberOfBubbles { get; private set; }

        public float CurrentSpeedUpOn { get; private set; }

        private int _currentWave;
        
        private readonly int _durationOfOneDifficultly;

        public DifficultyOfGameModel(int durationOfOneDifficultly, int startNumberOfBubbles, float startSpeedUpOn)
        {
            _currentWave = 1;
            _durationOfOneDifficultly = durationOfOneDifficultly;
            CurrentNumberOfBubbles = startNumberOfBubbles;
            CurrentSpeedUpOn = startSpeedUpOn;
        }

        /// <summary>
        /// Проверяет, нужно усложнять игру или нет, и если нужно, усложняет
        /// </summary>
        public void CheckDifficulty()
        {
            if (_currentWave % _durationOfOneDifficultly == 0)
            {
                MonoBehaviour.print("Next wave");
                // Усложняем игры
            }

            ModelChanged();
            _currentWave++;
        }
    }
}