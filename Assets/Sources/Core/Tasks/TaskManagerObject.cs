using UnityEngine;

namespace Sources.Core.Tasks
{
    public static class TaskManagerObject
    {
        private static MonoBehaviour _coroutineHost;
        
        
        public static MonoBehaviour CoroutineHost()
        {
            if (_coroutineHost == null)
            {
                var gameObject = new GameObject("[CoroutineHost]");
                _coroutineHost = gameObject.AddComponent<MonoBehaviour>();
            }

            return _coroutineHost;
        }
        
    }
}