using UnityEngine;

namespace Sources.Core.Bubble
{
    /// <summary>
    /// Рассчитывает скорость передвижения пузыря
    /// </summary>
    public class CalculatorSpeedBubble
    {
        private readonly float _speedUpOn;

        public CalculatorSpeedBubble(float speedUpOn)
        {
            _speedUpOn = speedUpOn;
        }

        public float GetSpeedBasedOnSize(int size, Vector3 startPosition, Vector3 endPosition)
        {
            var distanceBetweenStartEnd = Vector3.Distance(startPosition, endPosition);
            return distanceBetweenStartEnd / size * _speedUpOn;
        }
    }
}