using System;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
    public class LoaderAssistant: MonoBehaviour, ILoaderTexture, ILoaderMaterial, ILoaderGameObject, ILoaderFont
    {
        [SerializeField, Header("Ссылка до bundle")]
        private string _bundleUrl;

        private ObjectLoaderFromAssetBundle _loaderFromAssetBundle;

        private void Awake()
        {
            _loaderFromAssetBundle = new ObjectLoaderFromAssetBundle(_bundleUrl, new WorkerWithCache());
        }

        public void LoadMaterial(string nameBundle, string assetName, Action<Material> response)
        {
        }

        public void LoadFont(string nameBundle, string assetName, Action<Font> response)
        {
            StartCoroutine(_loaderFromAssetBundle.LoadFontFromServer(nameBundle, assetName, response));
        }
    }
}