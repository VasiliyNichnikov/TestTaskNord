using System.Collections.Generic;
using Sources.Core.Bubble;
using Sources.Core.Utils;
using UnityEngine;

namespace Sources.Core.Generator
{
    public class BubbleMaker
    {
        private readonly CalculatorSizeBubble _calculatorSize;
        private readonly CreatorBubbleObject _creatorBubbleObject;

        public BubbleMaker(CalculatorSizeBubble calculatorSize, CreatorBubbleObject creatorBubbleObject)
        {
            _calculatorSize = calculatorSize;
            _creatorBubbleObject = creatorBubbleObject;
        }
        
        /// <summary>
        /// Создает numberOfBubbles пузырей вдоль ширины экрана
        /// </summary>
        /// <param name="numberOfBubbles">Сколько пузырей нужно создать</param>
        /// <param name="generator">Класс реализующий интерейс благодаря которому происходит отписка созданных пузырей</param>
        /// <param name="speedUpOn">Служить для ускорения пузыря на заданое значение</param>
        /// <returns></returns>
        public List<SampleBubble> CreateBubbles(int numberOfBubbles, IGenerator generator, CalculatorSpeedBubble calculatorSpeed)
        {
            // Объявляем и инициализируем начальные данные
            var spawnPositionBubble = new Vector3(
                -ScreenSettings.HalfWidthScreen + ScreenSettings.BorderOnLeft,
                ScreenSettings.HalfHeightScreen + ScreenSettings.YShiftToGenerate, .0f);
            
            // Рассчитываем размер и пространство между пузырьками
            _calculatorSize.NumberOfBubbles = numberOfBubbles;
            _calculatorSize.Calculate();

            var createdSprites = new List<SampleBubble>();
            var spaceBetweenBubbles = _calculatorSize.SpaceBetweenBubbles;
            
            // Создаем пузыри с промежутками и добавляем каждый новый пузырь в список
            var bubbleSizes = _calculatorSize.BubbleSizes;
            for (var index = 0; index < _calculatorSize.NumberOfBubbles; index++)
            {
                var halfSizeBubble = bubbleSizes[index] / 2;
                spawnPositionBubble.x += halfSizeBubble;
                var sizeBubble = bubbleSizes[index];

                var numberScoreBubble = _calculatorSize.MaxSizeBubble / sizeBubble;
                var newBubble = _creatorBubbleObject.Create(generator, spawnPositionBubble, sizeBubble, numberScoreBubble, calculatorSpeed);
                createdSprites.Add(newBubble);
                
                spawnPositionBubble.x += halfSizeBubble + spaceBetweenBubbles;
            }

            return createdSprites;
        }
    }
}