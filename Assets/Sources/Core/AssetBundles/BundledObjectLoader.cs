using System.IO;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
	public class BundledObjectLoader : MonoBehaviour {

		void Start ()
		{
			var assetName = "bubble";
			var bundleName = "prefabs";

			var localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
			if (localAssetBundle == null)
			{
				Debug.LogError("Failed to load asset bundle");
				return;
			}

			var asset = localAssetBundle.LoadAsset<GameObject>(assetName);
			Instantiate(asset);
			localAssetBundle.Unload(false);
		}
	
	}
}
