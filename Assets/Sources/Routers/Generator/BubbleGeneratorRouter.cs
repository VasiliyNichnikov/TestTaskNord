using Sources.Factory;
using Sources.MVVM.Model.Generator;
using Sources.MVVM.View.Generator;
using Sources.MVVM.ViewModel.Generator;

namespace Sources.Routers.Generator
{
    public class BubbleGeneratorRouter: IBubbleGeneratorRouter
    {
        private readonly BubbleGeneratorModel _model;
        private readonly IViewCreator _viewCreator;
        
        public BubbleGeneratorRouter(IViewCreator creator, BubbleGeneratorModel model)
        {
            _model = model;
            _viewCreator = creator;

            CreateGenerator();
        }

        private void CreateGenerator()
        {
            var viewModel = new BubbleGeneratorViewModel(_model);
            var view = _viewCreator.Instantiate<BubbleGeneratorView>();
            view.Init(viewModel);
        }
        
    }
}