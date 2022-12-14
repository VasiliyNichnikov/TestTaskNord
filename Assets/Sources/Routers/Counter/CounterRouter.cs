using Sources.Factory;
using Sources.MVVM.Model.Counter;
using Sources.MVVM.View.Counter;
using Sources.MVVM.ViewModel.Counter;
using UnityEngine;

namespace Sources.Routers.Counter
{
    public class CounterRouter: ICounterRouter
    {
        private readonly CounterModel _model;
        private readonly IViewCreator _viewCreator;

        public CounterRouter(IViewCreator creator, CounterModel model)
        {
            _model = model;
            _viewCreator = creator;
        }
        
        public void CreateCounter()
        {
            var viewModel = new CounterViewModel(_model);
            var view = _viewCreator.Instantiate<CounterView>();
            view.Init(viewModel);
        }

        public void UpdateCounter(int plus)
        {
            _model.UpdateCounter(plus);
        }
    }
}