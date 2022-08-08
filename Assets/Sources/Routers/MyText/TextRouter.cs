using Sources.Factory;
using Sources.MVVM.Model.MyText;
using Sources.MVVM.View.MyText;
using Sources.MVVM.ViewModel.MyText;
using UnityEngine;

namespace Sources.Routers.MyText
{
    public class TextRouter : ITextRouter
    {
        public Font Font
        {
            get { return _model.Font; }
            set { _model.Font = value; }
        }

        private readonly TextModel _model;
        private readonly IViewCreator _viewCreator;

        public TextRouter(IViewCreator creator, TextModel model)
        {
            _model = model;
            _viewCreator = creator;

            InitText();
        }

        public void LoadResourcesInText(LoaderTextModel loaderModel)
        {
            var viewModel = new LoaderTextViewModel(loaderModel);
            var view = _viewCreator.Instantiate<LoaderTextView>();
            view.Init(viewModel);
        }
        
        private void InitText()
        {
            var viewModel = new TextViewModel(_model);
            var view = _viewCreator.Instantiate<TextView>();
            view.Init(viewModel);
        }
    }
}