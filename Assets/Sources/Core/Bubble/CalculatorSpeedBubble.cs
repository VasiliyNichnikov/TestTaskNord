using UnityEngine;

namespace Sources.Core.Bubble
{
    /// <summary>
    /// Рассчитывает скорость передвижения пузыря
    /// </summary>
    public class CalculatorSpeedBubble
    {
        private readonly float _averageSpeedMultiplication;
        private readonly float _rangeSpeed;

        public CalculatorSpeedBubble(float averageSpeedMultiplication, float rangeSpeed)
        {
            _averageSpeedMultiplication = averageSpeedMultiplication;
            _rangeSpeed = rangeSpeed;
        }

        public float GetSpeedBasedOnSize(int size, Vector3 startPosition, Vector3 endPosition)
        {
            var speedMultiplication = GetSpeedMultiplication();
            var distanceBetweenStartEnd = Vector3.Distance(startPosition, endPosition);
            return distanceBetweenStartEnd / size * speedMultiplication;
        }

        private float GetSpeedMultiplication()
        {
            var range = Random.Range(0, _rangeSpeed);
            return _averageSpeedMultiplication + range;
        }
    }
}