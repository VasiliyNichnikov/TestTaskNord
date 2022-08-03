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
			var model = new BubbleModel { Sprite = _testSprite};
			var bubbleViewModel = new BubbleViewModel(model);
			_bubbleView.Init(bubbleViewModel);
			// todo нарушение паттерна
			model.Changed();
		}
	}
}

