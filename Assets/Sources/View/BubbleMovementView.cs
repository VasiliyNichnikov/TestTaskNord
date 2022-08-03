using Sources.Core.Binder;
using Sources.ViewModel;


namespace Sources.View
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
