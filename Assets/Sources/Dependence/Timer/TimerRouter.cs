using Sources.Factory;
using Sources.MVVM.Model.Timer;
using Sources.MVVM.View.Timer;
using Sources.MVVM.ViewModel.Timer;
using UnityEngine;

namespace Sources.Dependence.Timer
{
    public class TimerRouter: ITimerRouter
    {
        private readonly IViewCreator _viewCreator;
        private readonly TimerModel _model;
        
        public TimerRouter(GameObject gameObject, TimerModel model)
        {
            _model = model;
            _viewCreator = new GuiFactory(gameObject);
        }
        
        public void Run()
        {
            var viewModel = new TimerViewModel(_model);
            var view = _viewCreator.Instantiate<TimerView>();
            view.Init(viewModel);
        }
    }
}