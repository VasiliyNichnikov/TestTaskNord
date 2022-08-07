using Sources.Core.Bubble;
using UnityEngine;

namespace Sources.Routers.Generator
{
    public interface ILoaderDataForGeneratorRouter
    {
        bool IsLoaded { get; }
        SampleBubble LoadedPrefab { get; }
        Material[] LoadedMaterials { get; }
    }
}