using Sources.Factory;
using Sources.MVVM.Model.Counter;
using Sources.Routers.Counter;
using UnityEngine;

namespace Sources.Core.UI
{
    public class CounterUI : MonoBehaviour
    {
        public ICounterRouter Router { get; private set; }

        private void Start()
        {
            var model = new CounterModel();
            Router = new CounterRouter(new GuiFactory(gameObject), model);
            Router.CreateCounter();
        }
    }
}