using UnityEngine;

namespace Sources.Core.Tasks
{
    public class CoroutineHostForTask: MonoBehaviour
    {
        public static MonoBehaviour CoroutineHost
        {
            get
            {
                return _coroutineHost;
            }
        }
        
        private static MonoBehaviour _coroutineHost;

        private void Awake()
        {
            _coroutineHost = this;
        }
    }
}