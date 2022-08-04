﻿using Sources.Core.Binder;
using Sources.ViewModel.Bubble;

namespace Sources.View.Bubble
{
	public class BubbleMovementView: Subscriber<BubbleMovementViewModel>
	{
		public override void Init(BubbleMovementViewModel model)
		{
			base.Init(model);
			SubscribeGameObject(ViewModel.BubblePosition, position => transform.position = position);
		}
		
		private void Update()
		{
			ViewModel.Update();
		}
		
	}
}