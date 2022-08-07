using System.Collections;
using System.Collections.Generic;
using Sources.Core.AssetBundles;
using Sources.Core.Bubble;
using UnityEngine;

namespace Sources.MVVM.Model.Generator
{
    public class LoaderDataForGeneratorModel: BaseModel
    {
        public bool IsLoaded { get; private set; }
        public Material[] LoadedMaterials
        {
            get
            {
                return _loadedMaterials.ToArray();
            }
        }

        private bool IsMaterialLoaded
        {
            get
            {
                return _materials.AssetsName.Length == _loadedMaterials.Count;
            }
        }

        private bool IsTextureLoaded
        {
            get
            {
                return _textures.AssetsName.Length == _loadedTextures.Count;
            }
        }

        private bool IsPrefabLoaded
        {
            get
            {
                return LoadedPrefab != null;
            }
        }

        public SampleBubble LoadedPrefab { get; private set; }

        private readonly AssetBundleObject _textures;
        private readonly AssetBundleObject _materials;
        private readonly AssetBundleObject _prefab;

        private readonly List<Material> _loadedMaterials = new List<Material>();
        private readonly List<Texture> _loadedTextures = new List<Texture>();

        public LoaderDataForGeneratorModel(AssetBundleObject materials, AssetBundleObject textures, AssetBundleObject prefab)
        {
            _materials = materials;
            _textures = textures;
            _prefab = prefab;
        }

        public IEnumerator LoadDataFromServer()
        {
            LoadBubbleTextures();
            LoadBubbleMaterials();
            
            LoadBubblePrefab();

            while (IsMaterialLoaded == false || IsTextureLoaded == false || IsPrefabLoaded == false)
            {
                yield return null;
            }
            
            CombineMaterialsAndTextures();

            IsLoaded = true;
            
            ModelChanged();
        }
        
        private void LoadBubbleMaterials()
        {
            var nameBundle = _materials.NameBundle;
            foreach (var assetName in _materials.AssetsName)
            {
                ExternalResourceManager.LoadMaterial(nameBundle, assetName, null, LoadMaterial);
            }
        }

        private void LoadBubbleTextures()
        {
            var nameBundle = _textures.NameBundle;
            foreach (var assetName in _textures.AssetsName)
            {
                ExternalResourceManager.LoadTexture(nameBundle, assetName, null, LoadTexture);
            }
        }

        private void CombineMaterialsAndTextures()
        {
            for (int i = 0; i < _loadedMaterials.Count; i++)
            {
                if (i > _loadedTextures.Count - 1)
                {
                    MonoBehaviour.print("Break");
                    break;
                }
                
                _loadedMaterials[i].mainTexture = _loadedTextures[i];
            }
        }
        
        private void LoadBubblePrefab()
        {
            var nameBundle = _prefab.NameBundle;
            var assetName = _prefab.AssetsName[0];
            ExternalResourceManager.LoadGameObject(nameBundle, assetName, null, LoadPrefab);
        }

        private void LoadMaterial(Material newMaterial)
        {
            _loadedMaterials.Add(newMaterial);
        }

        private void LoadTexture(Texture newTexture)
        {
            _loadedTextures.Add(newTexture);
        }
        
        private void LoadPrefab(GameObject prefab)
        {
            LoadedPrefab = prefab.AddComponent<SampleBubble>();
        }
        
    }
}