using System;
using System.Collections;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
	public class ObjectLoaderFromAssetBundle
	{
		private readonly string _bundleUrl;


		public ObjectLoaderFromAssetBundle(string bundleUrl)
		{
			_bundleUrl = bundleUrl;
		}

		/// <summary>
		/// Загрузка текстуры с сервера 
		/// </summary>
		/// <param name="nameBundle">Название бандла в котором хранится текстура</param>
		/// <param name="assetName">Название самой текстуры, которую нужно выгрузить</param>
		/// <param name="response">Загруженная в случае успеха текстура отправиться в подписавшийся метод</param>
		/// <returns></returns>
		public IEnumerator LoadTextureFromServer(string nameBundle, string assetName, Action<Texture2D> response)
		{
			var readyBundleUrl = GetReadyUrl(nameBundle);
			using (var web = new WWW(readyBundleUrl))
			{
				yield return web;
				var remoteAssetBundle = web.assetBundle;

				if (remoteAssetBundle == null)
				{
					Debug.LogErrorFormat("Failed to load asset bundle");
					response(null);
					yield break;
				}
				
				var data = remoteAssetBundle.LoadAssetAsync<Texture2D>(assetName);
				response(data.asset as Texture2D);
				remoteAssetBundle.Unload(false);
			} 
		}
		
		/// <summary>
		/// Загрузка материала с сервера 
		/// </summary>
		/// <param name="nameBundle">Название бандла в котором хранится материал</param>
		/// <param name="assetName">Название самого материала, который нужно выгрузить</param>
		/// <param name="response">Загруженный в случае успеха материал отправиться в подписавшийся метод</param>
		/// <returns></returns>
		public IEnumerator LoadMaterialFromServer(string nameBundle, string assetName, Action<Material> response)
		{
			var readyBundleUrl = GetReadyUrl(nameBundle);
			using (var web = new WWW(readyBundleUrl))
			{
				yield return web;
				var remoteAssetBundle = web.assetBundle;

				if (remoteAssetBundle == null)
				{
					Debug.LogErrorFormat("Failed to load asset bundle");
					response(null);
					yield break;
				}
				
				var data = remoteAssetBundle.LoadAssetAsync<Material>(assetName);
				response(data.asset as Material);
				remoteAssetBundle.Unload(false);
			} 
		}
		
		/// <summary>
		/// Загрузка игрового объекта с сервера 
		/// </summary>
		/// <param name="nameBundle">Название бандла в котором хранится игровой объект</param>
		/// <param name="assetName">Название игрового объекта, который нужно выгрузить</param>
		/// <param name="response">Загруженный в случае успеха игровой объект отправиться в подписавшийся метод</param>
		/// <returns></returns>
		public IEnumerator LoadGameObjectFromServer(string nameBundle, string assetName, Action<GameObject> response)
		{
			var readyBundleUrl = GetReadyUrl(nameBundle);
			using (var web = new WWW(readyBundleUrl))
			{
				yield return web;
				var remoteAssetBundle = web.assetBundle;

				if (remoteAssetBundle == null)
				{
					Debug.LogErrorFormat("Failed to load asset bundle");
					response(null);
					yield break;
				}
				
				var data = remoteAssetBundle.LoadAssetAsync<GameObject>(assetName);
				response(data.asset as GameObject);
				remoteAssetBundle.Unload(false);
			} 
		}
		
		/// <summary>
		/// Загрузка шрифта с сервера 
		/// </summary>
		/// <param name="nameBundle">Название бандла в котором хранится шрифт</param>
		/// <param name="assetName">Название шрифта, который нужно выгрузить</param>
		/// <param name="response">Загруженный в случае успеха шрифт отправиться в подписавшийся метод</param>
		/// <returns></returns>
		// public IEnumerator LoadFontFromServer(string nameBundle, string assetName, Action<Font> response)
		// {
		// 	if (_workerWithCache.CheckCache(nameBundle, assetName))
		// 	{
		// 		var obj = _workerWithCache.GetFromCache(nameBundle, assetName);
		// 		response(obj as Font);
		// 		yield break;
		// 	}
		// 	
		// 	var readyBundleUrl = GetReadyUrl(nameBundle);
		// 	using (var web = new WWW(readyBundleUrl))
		// 	{
		// 		yield return web;
		// 		var remoteAssetBundle = web.assetBundle;
		//
		// 		if (remoteAssetBundle == null)
		// 		{
		// 			Debug.LogErrorFormat("Failed to load asset bundle");
		// 			response(null);
		// 			yield break;
		// 		}
		// 		
		// 		var data = remoteAssetBundle.LoadAssetAsync<Font>(assetName);
		// 		_workerWithCache.SendToCache(nameBundle, assetName, data.asset);
		// 		response(data.asset as Font);
		// 		remoteAssetBundle.Unload(false);
		// 	} 
		// }
		
		public IEnumerator LoadFontFromServerWithCache(string nameBundle, string assetName, Action<Font> response)
		{
			while (Caching.ready == false)
			{
				yield return null;
			}


			var readyBundleUrl = GetReadyUrl(nameBundle);
			using (var web = new WWW(readyBundleUrl + ".manifest"))
			{
				yield return web;
				
				// todo нужно проверять на ошибки (файл не найден и тп)
				if (web.isDone)
				{
					// MonoBehaviour.print(web.text);
					var hashRow = web.text.Split("\n".ToCharArray())[5];
					// MonoBehaviour.print(hashRow.Split(':')[1].Trim());
					var hash = Hash128.Parse(hashRow.Split(':')[1].Trim());
					
					if (hash.isValid)
					{
						var remoteAssetBundle = web.assetBundle;

						if (remoteAssetBundle == null)
						{
							Debug.LogErrorFormat("Failed to load asset bundle");
							response(null);
							yield break;
						}
						var data = remoteAssetBundle.LoadAssetAsync<Font>(assetName);
						response(data.asset as Font);
						remoteAssetBundle.Unload(false);
					}
					else
					{
						response(null);
					}
				}
				else
				{
					response(null);
				}
			}
		}
		
		private string GetReadyUrl(string nameBundle)
		{
			return _bundleUrl + "/" + nameBundle;
		}

	}
}
