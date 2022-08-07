using Sources.Core.AssetBundles;
using UnityEngine;

namespace Sources.MVVM.Model.Bubble
{
    public class BubbleLoaderModel : BaseModel
    {
        public Material Material { get; private set; }

        private readonly string _nameBundle;
        private readonly string _assetName;
        
        public BubbleLoaderModel(string nameBundle, string assetName)
        {
            _nameBundle = nameBundle;
            _assetName = assetName;
        }

        public void LoadMaterial()
        {
            ExternalResourceManager.LoadMaterial(_nameBundle, _assetName, null, ChangeMaterial);
        }

        private void ChangeMaterial(Material newMaterial)
        {
            Material = newMaterial;
            ModelChanged();
        }  
    }
}