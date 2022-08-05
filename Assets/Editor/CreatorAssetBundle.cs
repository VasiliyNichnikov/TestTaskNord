using System.IO;
using UnityEditor;
using Application = UnityEngine.Application;

namespace Editor
{
    public class CreatorAssetBundle
    {
        [MenuItem("Assets/Build AssetBundles")]
        private static void BuildAllAssetBundles()
        {
            var assetBundleDirectory = "Assets/AssetBundles";
            if (Directory.Exists(Application.streamingAssetsPath) == false)
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }

            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None,
                EditorUserBuildSettings.activeBuildTarget);
        }
    }
}