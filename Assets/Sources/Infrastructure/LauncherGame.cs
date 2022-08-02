using Sources.Model;
using Sources.View;
using Sources.ViewModel;
using UnityEngine;
namespace Sources.Infrastructure
{
	public class LauncherGame: MonoBehaviour
	{
		[SerializeField] private Sprite _testSprite;
		[SerializeField] private BubbleView _bubbleView;

		private void Start()
		{
			var model = new Bubble {Sprite = _testSprite, Size = 1.0f, Speed = 1.0f};
			
			_bubbleView.BindingContext = new BubbleViewModel();
			_bubbleView.BindingContext.Initialization(model);
			_bubbleView.BindingContext.Size.Value = 23;
			_bubbleView.Reveal();
		}
	}
}

