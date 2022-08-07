using Sources.Core.Bubble;
using Sources.Core.Utils;
using Sources.Factory;
using Sources.MVVM.Model.Bubble;
using Sources.Routers.Bubble;
using UnityEngine;

namespace Sources.Core.Generator
{
    public class CreatorBubbleObject
    {
        private readonly Transform _parentBubble;
        private readonly SampleBubble _prefabBubble;
        private readonly Material[] _allBubbleMaterials;

        public CreatorBubbleObject(Transform parentBubble, SampleBubble prefabBubble, Material[] allBubbleMaterials)
        {
            _parentBubble = parentBubble;
            _prefabBubble = prefabBubble;
            _allBubbleMaterials = allBubbleMaterials;
        }

        public SampleBubble Create(ICreatedBubble createdBubble, Vector3 startPosition, int sizeBubble, int numberScore, CalculatorSpeedBubble calculatorSpeedBubble)
        {
            // Объявление и инициализация начальной и конечной точки движения пузыря
            var endPosition = startPosition;
            endPosition.y = -ScreenSettings.HalfHeightScreen - sizeBubble;

            // Создание объекта пузыря и настройка его размера и материала
            var material = GetRandomMaterial();
            var bubble = Object.Instantiate(_prefabBubble, startPosition, Quaternion.identity);
            bubble.transform.SetParent(_parentBubble);
            bubble.ChangeSize(sizeBubble);
            bubble.ChangeMaterial(material);

            var speed = calculatorSpeedBubble.GetSpeedBasedOnSize(sizeBubble, startPosition, endPosition);
            
            var movementModel = new BubbleMovementModel(startPosition, endPosition, speed);
            var clickerModel = new BubbleClickerModel(bubble, createdBubble,  numberScore);
            IBubbleRouter router = new BubbleRouter(new GuiFactory(bubble.gameObject), movementModel, clickerModel);
            router.CreateBubble();

            return bubble;
        }
        
        private Material GetRandomMaterial()
        {
            var index = Random.Range(0, _allBubbleMaterials.Length);
            return _allBubbleMaterials[index];
        }
    }
}