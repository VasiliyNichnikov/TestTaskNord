using Sources.Factory;
using Sources.Model.Bubble;
using Sources.View.Bubble;
using Sources.ViewModel.Bubble;
using UnityEngine;

namespace Sources.Dependence.Bubble
{
    public class BubbleRouter: IBubbleRouter
    {
        private readonly BubbleMovementModel _movementModel;
        private readonly BubbleRemovalModel _removalModel;
        private readonly IViewCreator _viewCreator;

        public BubbleRouter(GameObject gameObject, BubbleMovementModel movementModel, BubbleRemovalModel removalModel)
        {
            _movementModel = movementModel;
            _removalModel = removalModel;
            _viewCreator = new GuiFactory(gameObject);
        }

        public void CreateMovement()
        {
            var viewModel = new BubbleMovementViewModel(_movementModel);
            var view = _viewCreator.Instantiate<BubbleMovementView>();
            view.Init(viewModel);
        }

        public void CreateRemoval()
        {
            var viewModel = new BubbleRemovalViewModel(_removalModel);
            var view = _viewCreator.Instantiate<BubbleRemovalView>();
            view.Init(viewModel);
        }
        
        public void CreateClicker()
        {
            
        }
        
    }
}