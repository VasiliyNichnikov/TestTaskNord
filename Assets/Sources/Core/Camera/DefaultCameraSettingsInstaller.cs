using UnityEngine;

namespace Sources.Core.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class DefaultCameraSettingsInstaller : MonoBehaviour
    {
        private UnityEngine.Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<UnityEngine.Camera>();
            _camera.orthographicSize = _camera.pixelHeight / 2;
        }
    }
}