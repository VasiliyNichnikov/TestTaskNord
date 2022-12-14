using System;
using System.Collections;
using Sources.Core.AssetBundles;
using Sources.Core.RangeValues;
using Sources.Core.UI;
using Sources.Factory;
using Sources.MVVM.Model.Generator;
using Sources.Routers.Generator;
using UnityEngine;

namespace Sources.Core.Generator
{
    public class BubbleGeneratorObject : MonoBehaviour
    {
        [SerializeField] private Transform _parentBubble;
        [SerializeField] private AssetBundleObject _prefabBubble;
        [SerializeField] private AssetBundleObject _texturesBubble;
        [SerializeField] private AssetBundleObject _materialsBubble;
        [SerializeField] private int _minSizeBubble;
        [SerializeField] private int _maxSizeBubble;
        [SerializeField] private CounterUI _counterRouter;

        [SerializeField] private int _durationOfOneDifficultly;
        [SerializeField] private RangeValueWithStepInt _rangeNumberBabbles;
        [SerializeField] private RangeValueWithStepFloat _rangeSpeedUpOn;
        
        private ILoaderDataForGeneratorRouter _loaderDataForGenerator;
        private IDifficultyOfGameRouter _difficultyOfGameRouter;
        private IBubbleGeneratorRouter _bubbleGeneratorRouter;

        private void Start()
        {
            StartCoroutine(LoadingDataFromServerAndRunGenerator());
        }

        private IEnumerator LoadingDataFromServerAndRunGenerator()
        {
            var model = new LoaderDataForGeneratorModel(_materialsBubble, _texturesBubble, _prefabBubble);
            _loaderDataForGenerator = new LoaderDataForGeneratorRouter(new GuiFactory(gameObject), model);

            while (_loaderDataForGenerator.IsLoaded == false)
            {
                yield return null;
            }

            CreateDifficultlyOfGameRouter();
            CreateGeneratorRouter();
        }

        private void CreateDifficultlyOfGameRouter()
        {
            var model = new DifficultyOfGameModel(_durationOfOneDifficultly, _rangeNumberBabbles, _rangeSpeedUpOn);
            _difficultyOfGameRouter = new DifficultyOfGameRouter(new GuiFactory(gameObject), model);
        }

        private void CreateGeneratorRouter()
        {
            var bubbleMaker = GetBubbleMaker();
            var model = new BubbleGeneratorModel(bubbleMaker, _counterRouter.Router, _difficultyOfGameRouter);
            _bubbleGeneratorRouter = new BubbleGeneratorRouter(new GuiFactory(gameObject), model);
        }

        private BubbleMaker GetBubbleMaker()
        {
            var calculatorSize = new CalculatorSizeBubble(_minSizeBubble, _maxSizeBubble);
            var creatorBubbleObject = new CreatorBubbleObject(_parentBubble, _loaderDataForGenerator.LoadedPrefab,
                _loaderDataForGenerator.LoadedMaterials);

            var bubbleMaker = new BubbleMaker(calculatorSize, creatorBubbleObject);
            return bubbleMaker;
        }
    }
}