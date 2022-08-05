using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.MVVM.Model.Counter;

namespace Sources.MVVM.ViewModel.Counter
{
    public class CounterViewModel: BaseViewModel<CounterModel>
    {
        private readonly ReactiveProperty<string> _counter = new ReactiveProperty<string>();

        public CounterViewModel(CounterModel model) : base(model)
        {
        }

        protected override void OnChanged()
        {
            _counter.Value = Model.Counter.ToString();
        }

        public IReactiveProperty<string> GetCounter()
        {
            return _counter;
        }
    }
}