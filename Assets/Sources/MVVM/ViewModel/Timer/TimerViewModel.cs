using Sources.Core.Rx;
using Sources.Infrastructure;
using Sources.MVVM.Model.Timer;

namespace Sources.MVVM.ViewModel.Timer
{
    public class TimerViewModel: BaseViewModel<TimerModel>
    {
        private readonly ReactiveProperty<string> _timeInSeconds = new ReactiveProperty<string>();
        

        public TimerViewModel(TimerModel model) : base(model)
        {
        }

        protected override void OnChanged()
        {
            _timeInSeconds.Value = Model.ElapsedTimeInSeconds.ToString();
        }

        public void UpdateTime()
        {
            Model.Change();
        }
        
        public IReactiveProperty<string> GetTimeInSeconds()
        {
            return _timeInSeconds;
        }
    }
}