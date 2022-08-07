using Sources.Factory;
using Sources.MVVM.Model.Generator;
using Sources.MVVM.View.Generator;
using Sources.MVVM.ViewModel.Generator;

namespace Sources.Routers.Generator
{
    public class DifficultyOfGameRouter: IDifficultyOfGameRouter
    {
        public int CurrentNumberOfBubbles
        {
            get
            {
                return _model.CurrentNumberOfBubbles;
            }
        }

        public float CurrentSpeedUpOn
        {
            get
            {
                return _model.CurrentSpeedUpOn;
            }
        }

        private readonly IViewCreator _creator;
        private readonly DifficultyOfGameModel _model;
        
        public DifficultyOfGameRouter(IViewCreator creator, DifficultyOfGameModel model)
        {
            _model = model;
            _creator = creator;
            
            InitDifficulty();
        }

        private void InitDifficulty()
        {
            var viewModel = new DifficultyOfGameViewModel(_model);
            var view = _creator.Instantiate<DifficultyOfGameView>();
            view.Init(viewModel);
        }
        
        public void CheckDifficulty()
        {
            _model.CheckDifficulty();
        }
    }
}