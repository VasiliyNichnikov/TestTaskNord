using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace Sources.Core.AssetBundles
{
    public class AssetBundleWrapper
    {
#if UNITY_EDITOR
        private readonly List<string> _assets;

        public AssetBundleWrapper(string url)
        {
            var uri = new Uri(url);
            var bundleName = Path.GetFileNameWithoutExtension(uri.LocalPath);

            _assets = new List<string>(AssetDatabase.GetAssetPathsFromAssetBundle(bundleName));
        }

        public T LoadAsset<T>(string name) where T : UnityEngine.Object
        {
            var assetPath = _assets.Find(item =>
            {
                var assetName = Path.GetFileNameWithoutExtension(item);
                return string.CompareOrdinal(name, assetName) == 0;
            });

            if (string.IsNullOrEmpty(assetPath) == false)
            {
                return AssetDatabase.LoadAssetAtPath<T>(assetPath);
            }

            return null;
        }

        public T[] LoadAssets<T>() where T : UnityEngine.Object
        {
            var returnedValues = new List<T>();

            foreach (var assetPath in _assets)
            {
                returnedValues.Add(AssetDatabase.LoadAssetAtPath<T>(assetPath));
            }

            return returnedValues.ToArray();
        }

        public void LoadAssetAsync<T>(string name, Action<T> result) where T : UnityEngine.Object
        {
            result(LoadAsset<T>(name));
        }

        public void LoadAssetsAsync<T>(Action<T[]> result) where T : UnityEngine.Object
        {
            result(LoadAssets<T>());
        }

        public string[] GetAllScenePaths()
        {
            return _assets.ToArray();
        }

        public void Unload(bool includeAllLoadedAssets = false)
        {
            _assets.Clear();
        }
#else
        private readonly AssetBundle _assetBundle;

        public AssetBundleWrapper(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;
        }

        public T LoadAsset<T>(string name) where T : UnityEngine.Object
        {
            return _assetBundle.LoadAsset<T>(name);
        }

        public T[] LoadAssets<T>() where T : UnityEngine.Object
        {
            return _assetBundle.LoadAllAssets<T>();
        }

        public void LoadAssetAsync<T>(string name, Action<T> result) where T : UnityEngine.Object
        {
            // todo сделать через TaskManager
        }

        public void LoadAssetsAsync<T>(Action<T[]> result) where T : UnityEngine.Object
        {
            // todo сделать через TaskManager
        }

        public string[] GetAllScenePaths()
        {
            return _assetBundle.GetAllScenePaths();
        }

        public void Unload(bool includeAllLoadedAssets = false)
        {
            _assetBundle.Unload(includeAllLoadedAssets);
        }
#endif
    }
}