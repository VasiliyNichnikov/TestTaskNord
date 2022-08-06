using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.MVVM.Model.Generator;

namespace Sources.MVVM.ViewModel.Generator
{
    public class BubbleGeneratorViewModel: BaseViewModel<BubbleGeneratorModel>
    {
        public BubbleGeneratorViewModel(BubbleGeneratorModel model) : base(model)
        {
        }

        public void StartGeneration()
        {
            Model.StartGeneration();
        }
        
        protected override void OnChanged()
        {
        }
    }
}