using Sources.Core.Bubble;
using Sources.Factory;
using Sources.MVVM.Model.Generator;
using Sources.MVVM.View.Generator;
using Sources.MVVM.ViewModel.Generator;
using UnityEngine;

namespace Sources.Routers.Generator
{
    public class LoaderDataForGeneratorRouter : ILoaderDataForGeneratorRouter
    {
        public bool IsLoaded
        {
            get { return _model.IsLoaded; }
        }

        public SampleBubble LoadedPrefab
        {
            get { return _model.LoadedPrefab; }
        }

        public Material[] LoadedMaterials
        {
            get { return _model.LoadedMaterials; }
        }

        private readonly IViewCreator _creator;
        private readonly LoaderDataForGeneratorModel _model;

        public LoaderDataForGeneratorRouter(IViewCreator creator, LoaderDataForGeneratorModel model)
        {
            _creator = creator;
            _model = model;

            InitLoaderForGenerator();
        }

        private void InitLoaderForGenerator()
        {
            var viewModel = new LoaderDataForGeneratorViewModel(_model);
            var view = _creator.Instantiate<LoaderDataForGeneratorView>();
            view.Init(viewModel);
        }
    }
}