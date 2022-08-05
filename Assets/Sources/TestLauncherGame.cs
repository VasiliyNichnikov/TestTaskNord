using UnityEngine;

namespace Sources
{
	public class TestLauncherGame: MonoBehaviour
	{
		[SerializeField] private Camera _camera;
		
		private void Start()
		{
			// todo написано для тестирования
			print("Orthographic size: " + _camera.pixelHeight / 2);
		}
	}
}

