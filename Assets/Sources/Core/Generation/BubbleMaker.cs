using System;
using System.Collections.Generic;
using Sources.Core.Bubble;
using Sources.Core.ObjectBubble;
using Sources.Core.Screen;
using Sources.Core.Utils;
using Sources.Dependence.Bubble;
using Sources.Model.Bubble;
using UnityEngine;

namespace Sources.Core.Generation
{
    /// <summary>
    /// Создает пузыри за экраном
    /// </summary>
    public class BubbleMaker : MonoBehaviour
    {
        [SerializeField] private Transform _bubbleParent;
        [SerializeField] private SampleBubble _bubblePrefab;
        [SerializeField] private int _minSizeBubble;


        private int _maxLengthForBubbles;

        private void Awake()
        {
            _maxLengthForBubbles =
                ScreenSettings.WidthScreen - ScreenSettings.BorderOnRight - ScreenSettings.BorderOnLeft;
        }


        public List<SampleBubble> CreateBubbles(ICreatedBubble createdBubble, int numberOfBubbles,
            float averageSpeedMultiplication, float rangeSpeed)
        {
            // Объявляем и инициализируем начальные данные
            var calculatorSpeed = new CalculatorSpeedBubble(averageSpeedMultiplication, rangeSpeed);
            var usedSpace = ScreenSettings.BorderOnLeft;
            var spawnPositionBubble = new Vector3(-ScreenSettings.HalfWidthScreen + usedSpace,
                ScreenSettings.HalfHeightScreen + ScreenSettings.YShiftToGenerate, .0f);

            // Заранее определяем каких размеров будут пузыри
            var bubbleSizes = new int[numberOfBubbles];
            var lengthOfBubbleSizes = 0.0f;
            for (var index = 0; index < numberOfBubbles; index++)
            {
                var number = RandomInRealTime.GetNumber(3);
                var sizeBubble = GetSizeBubble(number);

                if (lengthOfBubbleSizes + sizeBubble >= _maxLengthForBubbles)
                {
                    numberOfBubbles = index;
                    break;
                }

                bubbleSizes[index] = sizeBubble;
                lengthOfBubbleSizes += sizeBubble;
            }

            var createdSprites = new List<SampleBubble>();
            var spaceBetweenBubbles = (_maxLengthForBubbles - lengthOfBubbleSizes) / numberOfBubbles;

            // Создаем пузыри, отделяя их друг от друга
            for (var index = 0; index < numberOfBubbles; index++)
            {
                var newBubble = CreateBubble(createdBubble, spawnPositionBubble,
                    bubbleSizes[index], calculatorSpeed);
                spawnPositionBubble.x += bubbleSizes[index] + spaceBetweenBubbles;
                createdSprites.Add(newBubble);
            }

            return createdSprites;
        }

        private int GetSizeBubble(int number)
        {
            return _minSizeBubble * (number + 1);
        }

        private SampleBubble CreateBubble(ICreatedBubble createdBubble, Vector3 startPosition, int sizeBubble,
            CalculatorSpeedBubble calculatorSpeedBubble)
        {
            // Объявление и инициализация начальной и конечной точки движения пузыря
            var endPosition = startPosition;
            endPosition.y = -ScreenSettings.HalfHeightScreen - sizeBubble;

            // Создание объекта пузыря и настройка его размера
            var bubble = Instantiate(_bubblePrefab, startPosition, Quaternion.identity) as SampleBubble;
            bubble.transform.SetParent(_bubbleParent);
            bubble.ChangeSize(sizeBubble);

            var speed = calculatorSpeedBubble.GetSpeedBasedOnSize(sizeBubble, startPosition, endPosition);
            
            var movementModel = new BubbleMovementModel(startPosition, endPosition, speed);
            var clickerModel = new BubbleClickerModel(bubble, createdBubble, 1);
            IBubbleRouter router = new BubbleRouter(bubble.gameObject, movementModel, clickerModel);
            router.CreateMovement();
            router.CreateClicker();

            return bubble;
        }
    }
}