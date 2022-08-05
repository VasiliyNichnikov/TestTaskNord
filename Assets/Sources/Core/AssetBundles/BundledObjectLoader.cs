using System.Collections;
using Sources.Core.ObjectBubble;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
	public class BundledObjectLoader : MonoBehaviour
	{
		[SerializeField] private Material _test;
		private string _bundleUrl = "http://localhost/assetbundles/prefabs";
		private string _assetName = "BubbleDefault";
		
		private void Start ()
		{
			StartCoroutine(Load());
		}

		private IEnumerator Load()
		{
			using (WWW web = new WWW(_bundleUrl))
			{
				yield return web;
				var remoteAssetBundle = web.assetBundle;
				if (remoteAssetBundle == null)
				{
					Debug.LogError("Failed to load asset bundle");
					yield break;
				}
				var asset = remoteAssetBundle.LoadAsset<GameObject>(_assetName);
				
				Instantiate(asset);
				asset.GetComponent<SampleBubble>().ChangeMaterial(_test);
				asset.GetComponent<SampleBubble>().ChangeSize(32);
				remoteAssetBundle.Unload(false);
			}
		}
	
	}
}
