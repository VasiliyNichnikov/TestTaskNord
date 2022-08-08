using Sources.Core.Binder;
using Sources.MVVM.ViewModel.Generator;

namespace Sources.MVVM.View.Generator
{
    public class LoaderDataForGeneratorView: Subscriber<LoaderDataForGeneratorViewModel>
    {
        private void Start()
        {
            StartCoroutine(ViewModel.LoadDataFromServer());
        }
    }
}