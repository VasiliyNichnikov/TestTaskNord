using System;
using System.Collections.Generic;
using Sources.Core.Bubble;
using Sources.Core.MySprite;
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
    public class BubbleMaker : MonoBehaviour, IUnsubscribeBubble
    {
        [SerializeField] private Transform _bubbleParent;
        [SerializeField] private SampleSprite _bubblePrefab;
        [SerializeField] private int _minSizeBubble;
        
        private List<SampleSprite> _createdSprites;
        private int _maxLengthForBubbles;

        private void Awake()
        {
            _maxLengthForBubbles =
                ScreenSettings.WidthScreen - ScreenSettings.BorderOnRight - ScreenSettings.BorderOnLeft;
        }
        
        public void Unsubscribe(SampleSprite sprite)
        {
            if (_createdSprites == null)
                throw new Exception("Bubbles are not created");
            _createdSprites.Remove(sprite);
        }
        
        public void CreateBubbles(int numberOfBubbles,
            float averageSpeedMultiplication, float rangeSpeed)
        {
            // Объявляем и инициализируем начальные данные
            // _createdSprites = new int[numberOfBubbles];
            var calculatorSpeed = new CalculatorSpeedBubble(averageSpeedMultiplication, rangeSpeed);
            var usedSpace = ScreenSettings.BorderOnLeft;
            var spawnPositionBubble = new Vector3(-ScreenSettings.HalfWidthScreen + usedSpace,
                ScreenSettings.HalfHeightScreen, .0f);
        
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

            _createdSprites = new List<SampleSprite>();
            var spaceBetweenBubbles = (_maxLengthForBubbles - lengthOfBubbleSizes) / numberOfBubbles;
            
            // Создаем пузыри, отделяя их друг от друга
            for (var index = 0; index < numberOfBubbles; index++)
            {
                var newBubble = CreateBubble(spawnPositionBubble, bubbleSizes[index], calculatorSpeed);
                spawnPositionBubble.x += bubbleSizes[index] + spaceBetweenBubbles;
                _createdSprites.Add(newBubble);
            }
        }
        
        private int GetSizeBubble(int number)
        {
            return _minSizeBubble * (number + 1);
        }
        
        private SampleSprite CreateBubble(Vector3 startPosition, int sizeBubble, CalculatorSpeedBubble calculatorSpeedBubble)
        {
            // Объявление и инициализация начальной и конечной точки движения пузыря
            var endPosition = startPosition;
            endPosition.y = -ScreenSettings.HalfHeightScreen - sizeBubble;
            
            // Создание объекта пузыря и настройка его размера
            var bubble = Instantiate(_bubblePrefab, startPosition, Quaternion.identity) as SampleSprite;
            bubble.transform.SetParent(_bubbleParent);
            bubble.ChangeSize(sizeBubble);
            
            var speed = calculatorSpeedBubble.GetSpeedBasedOnSize(sizeBubble, startPosition, endPosition);
           
            // Создание всех зависимостей пузыря
            var movementModel = new BubbleMovementModel(startPosition, endPosition, speed);
            IBubbleRouter router = new BubbleRouter(bubble.gameObject, movementModel);
            router.CreateMovement();
            
            return bubble;
        }
    }
}