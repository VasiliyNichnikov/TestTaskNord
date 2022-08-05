using Sources.Dependence.Counter;
using Sources.Model.Counter;
using UnityEngine;

namespace Sources.Core.UI
{
    public class CounterUI : MonoBehaviour
    {
        public ICounterRouter Router { get; private set; }

        private void Start()
        {
            var model = new CounterModel();
            Router = new CounterRouter(gameObject, model);
            Router.CreateCounter();
        }
    }
}