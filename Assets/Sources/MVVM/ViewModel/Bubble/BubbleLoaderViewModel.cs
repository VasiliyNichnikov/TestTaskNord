using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.MVVM.Model.Bubble;
using UnityEngine;

namespace Sources.MVVM.ViewModel.Bubble
{
    public class BubbleLoaderViewModel : BaseViewModel<BubbleLoaderModel>
    {
        private readonly ReactiveProperty<Material> _bubbleMaterial = new ReactiveProperty<Material>();

        public BubbleLoaderViewModel(BubbleLoaderModel model) : base(model)
        {
        }

        protected override void OnChanged()
        {
            _bubbleMaterial.Value = Model.Material;
        }

        public IReactiveProperty<Material> GetMaterial()
        {
            return _bubbleMaterial;
        }
    }
}