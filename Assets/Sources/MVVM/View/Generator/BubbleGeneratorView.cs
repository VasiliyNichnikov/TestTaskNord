using Sources.Core.Binder;
using Sources.MVVM.ViewModel.Generator;

namespace Sources.MVVM.View.Generator
{
    public class BubbleGeneratorView: Subscriber<BubbleGeneratorViewModel>
    {
        private void Start()
        {
            ViewModel.StartGeneration();
        }
    }
}