using System.IO;
using UnityEditor;
using Application = UnityEngine.Application;

namespace Editor.AssetBundles
{
    public class CreatorAssetBundle
    {
        [MenuItem("Assets/Build AssetBundles")]
        private static void BuildAllAssetBundles()
        {
            var assetBundleDirectory = "Assets/StreamingAssets";
            if (Directory.Exists(Application.streamingAssetsPath) == false)
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }

            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None,
                EditorUserBuildSettings.activeBuildTarget);
        }
    }
}