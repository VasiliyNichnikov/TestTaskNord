using Sources.Factory;
using Sources.Model.Counter;
using Sources.View.Counter;
using Sources.ViewModel.Counter;
using UnityEngine;

namespace Sources.Dependence.Counter
{
    public class CounterRouter: ICounterRouter
    {
        private readonly CounterModel _model;
        private readonly IViewCreator _viewCreator;

        public CounterRouter(GameObject gameObject, CounterModel model)
        {
            _model = model;
            _viewCreator = new GuiFactory(gameObject);
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