using Sources.Core.Binder;
using Sources.ViewModel.Generation;

namespace Sources.View.Generation
{
    public class BubbleCreatorView: Subscriber<BubbleCreatorViewModel>
    {
        private void Start()
        {
            ViewModel.CreateStartBubbles();
        }
    }
}