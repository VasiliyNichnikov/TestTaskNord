using Sources.Core.Bubble;
using Sources.Factory;
using Sources.MVVM.Model.Generator;
using Sources.Routers.Generator;
using UnityEngine;

namespace Sources.Core.Generator
{
    // todo создать отдельную папку для всех классов с Routers
    public class BubbleGeneratorObject: MonoBehaviour
    {
        // todo написано для тестирования (Нужно исправить)
        [SerializeField] private Transform _parentBubble;
        // todo должны отправляться в подгрузку (Начало)
        [SerializeField] private SampleBubble _prefabBubble;
        [SerializeField] private Material[] _allBubbleMaterials;
        // todo должны отправляться в подгрузку (Конец)
        [SerializeField] private int _minSizeBubble;
        [SerializeField] private int _maxSizeBubble;
        
        private IBubbleGeneratorRouter _router;

        private void Start()
        {
            var calculatorSize = new CalculatorSizeBubble(_minSizeBubble, _maxSizeBubble);
            var creatorBubbleObject = new CreatorBubbleObject(_parentBubble, _prefabBubble, _allBubbleMaterials);
            
            var bubbleMaker = new BubbleMaker(calculatorSize, creatorBubbleObject);
            var model = new BubbleGeneratorModel(bubbleMaker);
            _router = new BubbleGeneratorRouter(new GuiFactory(gameObject), model);
            _router.CreateGenerator();
        }
    }
}