using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Core.Tasks;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
    public class Network
    {
        public TaskManager TaskManager
        {
            get
            {
                return _taskManager;
            }
        }

        private readonly List<WWW> _currentRequests = new List<WWW>();
        private readonly TaskManager _taskManager = new TaskManager();

        public void Request(string url, Hash128 hash, Action<float> progress, Action<AssetBundle> response,
            TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            _taskManager.AddTask(WebRequestLoadFromCacheOrDownload(url, hash, progress, web =>
            {
                var assetBundle = web.assetBundle;
                if (assetBundle == null || string.IsNullOrEmpty(web.error) == false)
                {
                    Debug.LogWarningFormat("[Network] error request [{0}]", web.error);
                    response(null);
                }
                else
                {
                    response(assetBundle);
                }
            }), priority).Subscribe(() => _taskManager.Restore());
        }

        public void Request(string url, Action<float> progress, Action<string> response,
            TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            _taskManager.AddTask(WebRequestDefaultWWW(url, progress, web =>
            {
                if (web.isDone == false || string.IsNullOrEmpty(web.error) == false)
                {
                    Debug.LogWarningFormat("[Network] error request [{0}]", web.error);
                    response(null);
                }
                else
                {
                    response(web.text);
                }
            }), priority);
        }

        public void Clear()
        {
            _taskManager.Clear();

            foreach (var request in _currentRequests)
            {
                request.Dispose();
            }

            _currentRequests.Clear();
        }

        private IEnumerator WebRequestLoadFromCacheOrDownload(string url, Hash128 hash, Action<float> progress,
            Action<WWW> response)
        {
            var web = WWW.LoadFromCacheOrDownload(url, hash, 0);
            
            return WebRequest(web, progress, response);
        }

        private IEnumerator WebRequestDefaultWWW(string url, Action<float> progress, Action<WWW> response)
        {
            var web = new WWW(url);

            return WebRequest(web, progress, response);
        }

        private IEnumerator WebRequest(WWW request, Action<float> progress, Action<WWW> response)
        {
            while (Caching.ready == false)
            {
                yield return null;
            }

            if (progress != null)
            {
                _currentRequests.Add(request);

                while (request.isDone == false)
                {
                    progress(request.progress);
                    yield return null;
                }

                progress(1f);
            }
            else
            {
                yield return request;
            }
           
            response(request);

            if (_currentRequests.Contains(request))
            {
                _currentRequests.Remove(request);
            }
            
            request.Dispose();
        }
    }
}