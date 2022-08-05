using Sources.Core.Binder;
using Sources.ViewModel.Bubble;


namespace Sources.View.Bubble
{
    public class BubbleClickerView : Subscriber<BubbleClickerViewModel>
    {
        public override void Init(BubbleClickerViewModel model)
        {
            base.Init(model);
            SubscribeGameObject(ViewModel.GetScale(), scale => transform.localScale = scale);
        }

        private void OnMouseDown()
        {
            var action = ViewModel.ClickOnBubble();
            StartCoroutine(action);
        }
    }
}