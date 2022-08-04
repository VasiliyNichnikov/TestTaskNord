using Sources.Infrastructure;
using Sources.Model.Generation;

namespace Sources.ViewModel.Generation
{
    public class BubbleCreatorViewModel: BaseViewModel<BubbleCreatorModel>, IVMInit
    {
        public BubbleCreatorViewModel(BubbleCreatorModel model) : base(model)
        {
        }
        
        public void Init()
        {
            Model.Change();
        }
        
        protected override void OnChanged()
        {
        }
    }
}