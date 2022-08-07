using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Core.Tasks;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
    public class Network
    {
        private readonly List<WWW> _currentRequests = new List<WWW>();
        private readonly TaskManager _taskManager = new TaskManager();
        
        
        public void Request(string url, string assetName, Action<float> progress, Action<AssetBundle> response, TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            _taskManager.AddTask(WebRequestBundle(url, progress, (web) =>
            {
                var remoteAssetBundle = web.assetBundle;
                if (remoteAssetBundle == null)
                {
                    Debug.LogWarningFormat("[Network] error request [{0}]", web.error);
                    response(null);
                }
                else
                {
                    var data = remoteAssetBundle.LoadAsset<AssetBundle>(assetName);
                    response(data);
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
        
        private IEnumerator WebRequestBundle(string url, Action<float> progress, Action<WWW> response)
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