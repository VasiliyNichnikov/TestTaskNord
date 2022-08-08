using Sources.Factory;
using Sources.MVVM.Model.Timer;
using Sources.MVVM.View.Timer;
using Sources.MVVM.ViewModel.Timer;

namespace Sources.Routers.Timer
{
    public class TimerRouter: ITimerRouter
    {
        private readonly IViewCreator _viewCreator;
        private readonly TimerModel _model;
        
        public TimerRouter(IViewCreator creator, TimerModel model)
        {
            _model = model;
            _viewCreator = creator;
        }
        
        public void Run()
        {
            var viewModel = new TimerViewModel(_model);
            var view = _viewCreator.Instantiate<TimerView>();
            view.Init(viewModel);
        }
    }
}