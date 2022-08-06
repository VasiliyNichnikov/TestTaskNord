using System;
using Sources.Core.AssetBundles;
using Sources.Factory;
using Sources.MVVM.Model.Timer;
using Sources.Routers.Timer;
using UnityEngine;

namespace Sources.Core.UI
{
    public class TimerUI: MonoBehaviour
    {
        private ITimerRouter _router;

        
        private void Start()
        {
            var model = new TimerModel();
            _router = new TimerRouter(new GuiFactory(gameObject), model);
            _router.Run();
        }
    }
}