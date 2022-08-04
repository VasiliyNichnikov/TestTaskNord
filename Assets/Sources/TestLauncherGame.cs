using Sources.Core.Utils;
using Sources.Model.Generation;
using Sources.View.Generation;
using Sources.ViewModel.Generation;
using UnityEngine;

namespace Sources
{
	public class TestLauncherGame: MonoBehaviour
	{
		[SerializeField] private Transform _bubblesParent;
		[SerializeField] private GameObject[] _prefabsBubble;
		[SerializeField] private BubbleCreatorView _creatorView;

		[SerializeField] private Camera _camera;
		
		private void Start()
		{
			// todo написано для тестирования
			var creatorModel = new BubbleCreatorModel(_bubblesParent, _prefabsBubble);
			var creatorViewModel = new BubbleCreatorViewModel(creatorModel);
			_creatorView.Init(creatorViewModel);
			
			print("Orthographic size: " + _camera.pixelHeight / 2);
		}

		private void Update()
		{
			
		}
	}
}

