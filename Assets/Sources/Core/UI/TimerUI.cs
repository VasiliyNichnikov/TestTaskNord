﻿using Sources.Dependence.Timer;
using Sources.Model.Timer;
using UnityEngine;

namespace Sources.Core.UI
{
    public class TimerUI: MonoBehaviour
    {
        private ITimerRouter _router;

        private void Start()
        {
            var model = new TimerModel();
            _router = new TimerRouter(gameObject, model);
            _router.Run();
        }
    }
}