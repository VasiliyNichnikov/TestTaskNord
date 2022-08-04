using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.Model.Bubble;
using UnityEngine;

namespace Sources.ViewModel.Bubble
{
    public class BubbleClickerViewModel : BaseViewModel<BubbleClickerModel>
    {
        public IReactiveProperty<Sprite> BubbleSprite
        {
            get { return _bubbleSprite; }
        }

        private readonly ReactiveProperty<Sprite> _bubbleSprite = new ReactiveProperty<Sprite>();

        public BubbleClickerViewModel(BubbleClickerModel model) : base(model)
        {
        }

        public void ClickOnBubble()
        {
            Model.Change();
        }

        protected override void OnChanged()
        {
            _bubbleSprite.Value = Model.Sprite;
        }
    }
}