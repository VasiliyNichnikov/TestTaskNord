using System;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
    public interface ILoaderTexture
    {
        void LoadMaterial(string nameBundle, string assetName, Action<Material> response);
    }
}