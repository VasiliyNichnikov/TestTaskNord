using Sources.Model.Bubble;

namespace Sources.ViewModel.Bubble
{
    public class BubbleRemovalViewModel: BaseViewModel<BubbleRemovalModel>
    {
        public BubbleRemovalViewModel(BubbleRemovalModel model) : base(model)
        {
        }

        protected override void OnChanged()
        {
            throw new System.NotImplementedException();
        }
    }
}