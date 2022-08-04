using Sources.Model.Generation;

namespace Sources.ViewModel.Generation
{
    public class BubbleCreatorViewModel: BaseViewModel<BubbleCreatorModel>
    {
        public BubbleCreatorViewModel(BubbleCreatorModel model) : base(model)
        {
        }
        
        public void CreateStartBubbles()
        {
            Model.Change();
        }
        
        protected override void OnChanged()
        {
        }
    }
}