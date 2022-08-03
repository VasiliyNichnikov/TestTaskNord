using Sources.Core.Binder;
using Sources.ViewModel;
using Sources.ViewModel.Bubble;

namespace Sources.View.Bubble
{
	public class BubbleMovementView: Subscriber<BubbleMovementViewModel>
	{
		private BubbleMovementViewModel _viewModel;
		
		public override void Init(BubbleMovementViewModel model)
		{
			_viewModel = model;

			SubscribeGameObject(_viewModel.BubblePosition, position => transform.position = position);
		}

		private void OnDisable()
		{
			_viewModel.Dispose();
		}
		
		private void Update()
		{
			_viewModel.Update();
		}
		
	}
}
