using Sources.Model.Bubble;


namespace Sources.ViewModel.Bubble
{
    public class BubbleClickerViewModel : BaseViewModel<BubbleClickerModel>
    {
        public BubbleClickerViewModel(BubbleClickerModel model) : base(model)
        {
        }

        public void ClickOnBubble()
        {
            Model.Change();
        }

        protected override void OnChanged()
        {
        }
    }
}