using Sources.Factory;
using Sources.MVVM.Model.MyText;
using Sources.MVVM.View.MyText;
using Sources.MVVM.ViewModel.MyText;
using UnityEngine;

namespace Sources.Routers.MyText
{
    public class TextRouter: ITextRouter
    {
        private readonly TextModel _model;
        private readonly IViewCreator _viewCreator;

        public TextRouter(IViewCreator creator, TextModel model)
        {
            _model = model;
            _viewCreator = creator;
        }
        
        public void CreateText()
        {
            var viewModel = new TextViewModel(_model);
            var view = _viewCreator.Instantiate<TextView>();
            view.Init(viewModel);
        }
    }
}