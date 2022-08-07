using Sources.Core.Binder;
using Sources.MVVM.ViewModel.Bubble;
using UnityEngine;

namespace Sources.MVVM.View.Bubble
{
    public class BubbleLoaderView: Subscriber<BubbleLoaderViewModel>
    {
        private MeshRenderer _renderer; 
        
        public override void Init(BubbleLoaderViewModel model)
        {
            base.Init(model);
            SubscribeGameObject(model.GetMaterial(), material => _renderer.material = material);
        }

        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
        }
    }
}