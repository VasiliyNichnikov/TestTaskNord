using Sources.MVVM.Model.MyText;

namespace Sources.MVVM.ViewModel.MyText
{
    public class LoaderTextViewModel: BaseViewModel<LoaderTextModel>
    {
        public LoaderTextViewModel(LoaderTextModel model) : base(model)
        {
        }

        protected override void OnChanged()
        {
        }
    }
}