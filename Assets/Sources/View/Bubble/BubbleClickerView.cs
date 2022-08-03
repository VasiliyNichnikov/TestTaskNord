using Sources.Core.Binder;
using Sources.ViewModel;
using Sources.ViewModel.Bubble;
using UnityEngine;

namespace Sources.View.Bubble
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BubbleClickerView: Subscriber<BubbleClickerViewModel>
    {
        private SpriteRenderer _renderer;
        private BubbleClickerViewModel _viewModel;
        
        public override void Init(BubbleClickerViewModel model)
        {
            _viewModel = model;

            SubscribeGameObject(_viewModel.BubbleSprite, sprite => _renderer.sprite = sprite);
        }
        
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
        
        private void OnDisable()
        {
            _viewModel.Dispose();
        }
        
        private void OnMouseDown()
        {
            _viewModel.OnMouseDown();
        }
    }
}