using Sources.Core.Binder;
using Sources.ViewModel;
using UnityEngine;

namespace Sources.View
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class BubbleView: Subscriber
	{
		private SpriteRenderer _renderer;
		private BubbleViewModel _viewModel;
		
		public void Init(BubbleViewModel model)
		{
			_viewModel = model;
			Subscribe(_viewModel.GetSprite(), sprite => _renderer.sprite = sprite);
		}
		
		private void Awake()
		{
			_renderer = GetComponent<SpriteRenderer>();
		}
	}
}
