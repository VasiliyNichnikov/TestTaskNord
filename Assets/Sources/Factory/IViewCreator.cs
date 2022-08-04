using UnityEngine;

namespace Sources.Factory
{
    public interface IViewCreator
    {
        TView Instantiate<TView> () where TView : MonoBehaviour;
    }
}