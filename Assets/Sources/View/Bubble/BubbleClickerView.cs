using Sources.Core.Binder;
using Sources.ViewModel.Bubble;
using UnityEngine;

namespace Sources.View.Bubble
{
    public class BubbleClickerView: Subscriber<BubbleClickerViewModel>
    {
        private SpriteRenderer _renderer;

        public override void Init(BubbleClickerViewModel model)
        {
            base.Init(model);
            SubscribeGameObject(ViewModel.BubbleSprite, sprite => _renderer.sprite = sprite);
        }
        
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnMouseDown()
        {
            ViewModel.OnMouseDown();
        }
    }
}