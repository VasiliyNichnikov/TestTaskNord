using Sources.Factory;
using Sources.Model.Bubble;
using Sources.View.Bubble;
using Sources.ViewModel.Bubble;
using UnityEngine;

namespace Sources.Dependence.Bubble
{
    public class BubbleRouter : IBubbleRouter
    {
        private readonly BubbleMovementModel _movementModel;
        private readonly BubbleClickerModel _clickerModel;
        private readonly IViewCreator _viewCreator;

        public BubbleRouter(GameObject gameObject, BubbleMovementModel movementModel, BubbleClickerModel clickerModel)
        {
            _clickerModel = clickerModel;
            _movementModel = movementModel;
            _viewCreator = new GuiFactory(gameObject);
        }

        public void CreateMovement()
        {
            var viewModel = new BubbleMovementViewModel(_movementModel);
            var view = _viewCreator.Instantiate<BubbleMovementView>();
            view.Init(viewModel);
        }

        public void CreateClicker()
        {
            var viewModel = new BubbleClickerViewModel(_clickerModel);
            var view = _viewCreator.Instantiate<BubbleClickerView>();
            view.Init(viewModel);
        }
    }
}