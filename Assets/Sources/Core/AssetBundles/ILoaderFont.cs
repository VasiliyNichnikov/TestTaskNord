using System;
using UnityEngine;

namespace Sources.Core.AssetBundles
{
    public interface ILoaderFont
    {
        void LoadFont(string nameBundle, string assetName, Action<Font> response);
    }
}