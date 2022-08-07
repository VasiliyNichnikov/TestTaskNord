using Sources.Factory;
using Sources.MVVM.Model.Bubble;
using Sources.MVVM.View.Bubble;
using Sources.MVVM.ViewModel.Bubble;

namespace Sources.Routers.Bubble
{
    public class BubbleRouter : IBubbleRouter
    {
        private readonly BubbleMovementModel _movementModel;
        private readonly BubbleClickerModel _clickerModel;
        private readonly IViewCreator _viewCreator;

        public BubbleRouter(IViewCreator creator, BubbleMovementModel movementModel, BubbleClickerModel clickerModel)
        {
            _clickerModel = clickerModel;
            _movementModel = movementModel;
            _viewCreator = creator;
        }
        
        public void CreateBubble()
        {
            CreateClicker();
            CreateMovement();
        }

        private void CreateMovement()
        {
            var viewModel = new BubbleMovementViewModel(_movementModel);
            var view = _viewCreator.Instantiate<BubbleMovementView>();
            view.Init(viewModel);
        }

        private void CreateClicker()
        {
            var viewModel = new BubbleClickerViewModel(_clickerModel);
            var view = _viewCreator.Instantiate<BubbleClickerView>();
            view.Init(viewModel);
        }
    }
}