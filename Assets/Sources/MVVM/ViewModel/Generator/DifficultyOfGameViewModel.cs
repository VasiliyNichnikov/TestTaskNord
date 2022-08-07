using Sources.MVVM.Model.Generator;

namespace Sources.MVVM.ViewModel.Generator
{
    public class DifficultyOfGameViewModel: BaseViewModel<DifficultyOfGameModel>
    {
        public DifficultyOfGameViewModel(DifficultyOfGameModel model) : base(model)
        {
        }

        protected override void OnChanged()
        {
        }
    }
}