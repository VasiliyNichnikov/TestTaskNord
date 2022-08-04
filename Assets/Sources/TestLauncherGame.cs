using Sources.Model.Generation;
using Sources.View.Generation;
using Sources.ViewModel.Generation;
using UnityEngine;

namespace Sources
{
	public class TestLauncherGame: MonoBehaviour
	{
		[SerializeField] private Sprite _testSprite;
		[SerializeField] private Sprite[] _stages;
		[SerializeField] private GameObject _prefabBubble;
		[SerializeField] private BubbleCreatorView _creatorView;

		[SerializeField] private Camera _camera;
		
		private void Start()
		{
			// todo написано для тестирования
			var creatorModel = new BubbleCreatorModel(_prefabBubble, _testSprite, _stages);
			var creatorViewModel = new BubbleCreatorViewModel(creatorModel);
			_creatorView.Init(creatorViewModel);

			print("Orthographic size: " + _camera.pixelHeight / 2);
		}
	}
}

