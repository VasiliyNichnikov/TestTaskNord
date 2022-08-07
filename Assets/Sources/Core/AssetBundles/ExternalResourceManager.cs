using System;
using System.Text;
using Sources.Core.AssetBundles.Tasks;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
    public static class ExternalResourceManager
    {
        private const string _mainUrl = "http://localhost/assetbundles";
        private static readonly Network _network = new Network();
        
        public static void GetFont(string nameBundle, string assetName, 
            Action<float> progress, Action<Font> result,
            TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            var url = GetBundleUrl(nameBundle);
            GetAssetBundle(url, progress, bundle =>
            {
                var font = bundle.LoadAsset<Font>(assetName);
                result(font);
                bundle.Unload(false);
            }, priority);
        }

        public static void GetGameObject(string nameBundle, string assetName, Action<float> progress, Action<GameObject> result)
        {
            var url = GetBundleUrl(nameBundle);
            GetAssetBundle(url, progress, bundle =>
            {
                var gameObject = bundle.LoadAsset<GameObject>(assetName);
                result(gameObject);
                bundle.Unload(false);
            });
        }

        public static void GetTexture(string nameBundle, string assetName, Action<float> progress, Action<Texture2D> result)
        {
            var url = GetBundleUrl(nameBundle);
            GetAssetBundle(url, progress, bundle =>
            {
                var texture = bundle.LoadAsset<Texture2D>(assetName);
                result(texture);
                bundle.Unload(false);
            });
        }

        public static void GetMaterial(string nameBundle, string assetName, Action<float> progress, Action<Material> result)
        {
            var url = GetBundleUrl(nameBundle);
            GetAssetBundle(url, progress, bundle =>
            {
                var material = bundle.LoadAsset<Material>(assetName);
                result(material);
                bundle.Unload(false);
            });
        }

        private static void GetAssetBundle(string url, Action<float> progress,
            Action<AssetBundle> result,
            TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            var manifestFileUrl = string.Format("{0}.manifest", url);

            _network.Request(manifestFileUrl, null, (string manifest) =>
            {
                var hash = string.IsNullOrEmpty(manifest) ? (Hash128?)null : GetHashFromManifest(manifest);

                if (hash == null || hash.Value.isValid == false)
                {
                    // Загрузка hash из базы даных
                }
                else
                {
                    MonoBehaviour.print(Caching.IsVersionCached(url, hash.Value) ? "Load from cache" : "Download");
                    LoadAssetBundle(url, progress, result, hash.Value);
                }
            }, priority);
        }

        private static string GetBundleUrl(string nameBundle)
        {
            var returnKey = new StringBuilder(_mainUrl);
            returnKey.Append('/');
            returnKey.Append(nameBundle);
            return returnKey.ToString();
        }
        
        private static Hash128 GetHashFromManifest(string manifest)
        {
            var hashRow = manifest.Split("\n".ToCharArray())[5];
            var hash = Hash128.Parse(hashRow.Split(':')[1].Trim());

            return hash;
        }
        
        private static void LoadAssetBundle(string url,
            Action<float> progress,
            Action<AssetBundle> result,
            Hash128 bundleHash)
        {
            _network.Request(url, bundleHash, progress, result, TaskPriorityEnum.High);
            _network.TaskManager.Restore();
        }
    }
}