using Sources.Core.Binder;
using Sources.ViewModel.Bubble;


namespace Sources.View.Bubble
{
    public class BubbleClickerView : Subscriber<BubbleClickerViewModel>
    {
        private void OnMouseDown()
        {
            ViewModel.ClickOnBubble();
        }
    }
}