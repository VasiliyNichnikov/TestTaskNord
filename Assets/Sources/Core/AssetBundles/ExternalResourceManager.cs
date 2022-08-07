using System;
using Sources.Core.Tasks;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
    public static class ExternalResourceManager
    {
        private static readonly Network _network = new Network();
 
        public static void GetFont(string url, string assetName, 
            Action<float> progress, Action<Font> result,
            TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            GetAssetBundle(url, progress, assetWrapper =>
            {
                var font = assetWrapper.LoadAsset<Font>(assetName);
                result(font);
                assetWrapper.Unload(false);
            }, priority);
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