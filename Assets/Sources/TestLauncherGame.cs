using Sources.Model;
using Sources.View;
using Sources.ViewModel;
using UnityEngine;

namespace Sources
{
	public class TestLauncherGame: MonoBehaviour
	{
		[SerializeField] private Sprite _testSprite;
		[SerializeField] private BubbleMovementView _bubbleView;
		[SerializeField] private BubbleClickerView _bubbleClickerView;
		[SerializeField] private Sprite[] _stages;
		
		private void Start()
		{
			// todo написано для тестирования
			var start = _bubbleView.transform.position;
			var end = start;
			end.y = -7;

			var clickerModel = new BubbleClickerModel(_testSprite, _stages);
			var model = new BubbleMovementModel(start, end, 1.5f);

			var bubbleClickerViewModel = new BubbleClickerViewModel(clickerModel);
			var bubbleViewModel = new BubbleMovementViewModel(model);

			_bubbleClickerView.Init(bubbleClickerViewModel);
			_bubbleView.Init(bubbleViewModel);
		}
	}
}

