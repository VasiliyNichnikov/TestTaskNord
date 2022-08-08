using System.Collections;
using Sources.MVVM.Model.Generator;

namespace Sources.MVVM.ViewModel.Generator
{
    public class LoaderDataForGeneratorViewModel: BaseViewModel<LoaderDataForGeneratorModel>
    {
        public LoaderDataForGeneratorViewModel(LoaderDataForGeneratorModel model) : base(model)
        {
        }

        public IEnumerator LoadDataFromServer()
        {
            return Model.LoadDataFromServer();
        }
        
        protected override void OnChanged()
        {
        }
    }
}