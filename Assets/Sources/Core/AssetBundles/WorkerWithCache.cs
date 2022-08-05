using System.Collections.Generic;
using System.Text;

namespace Sources.Core.AssetBundles
{
    public class WorkerWithCache
    {
        private readonly Dictionary<string, object> _cache;

        public WorkerWithCache()
        {
            _cache = new Dictionary<string, object>();
        }
        
        public bool CheckCache(string nameBundle, string assetName)
        {
            var key = GetKey(nameBundle, assetName);
            return _cache.ContainsKey(key);
        }

        public object GetFromCache(string nameBundle, string assetName)
        {
            var key = GetKey(nameBundle, assetName);
            return _cache[key];
        }
		
        public void SendToCache(string nameBundle, string assetName, object obj)
        {
            var key = GetKey(nameBundle, assetName);
            _cache[key] = obj;
        }

        private string GetKey(string nameBundle, string assetName)
        {
            var builder = new StringBuilder(nameBundle);
            builder.Append('-');
            builder.Append(assetName);
            return builder.ToString();
        }
    }
}