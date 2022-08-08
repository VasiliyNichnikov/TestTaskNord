using UnityEngine;

namespace Sources.Core.AssetBundles
{
    [CreateAssetMenu(fileName = "NewAssetBundleObject", menuName = "CreateBundle/AssetBundle", order = 0)]
    public class AssetBundleObject : ScriptableObject
    {
        public string NameBundle
        {
            get
            {
                return _nameBundle.ToLower();
            }
        }

        public string[] AssetsName
        {
            get
            {
                return _assetsName;
            }
        }
        
        [SerializeField, Header("Название бандла")]
        private string _nameBundle;

        [SerializeField, Header("Имена объектов, которые есть в bundle")]
        private string[] _assetsName;
    }
}