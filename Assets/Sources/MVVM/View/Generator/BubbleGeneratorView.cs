using Sources.Core.Binder;
using Sources.MVVM.Model.Generator;
using Sources.MVVM.ViewModel.Generator;
using UnityEngine;

namespace Sources.MVVM.View.Generator
{
    public class BubbleGeneratorView: Subscriber<BubbleGeneratorViewModel>
    {
        private void Start()
        {
            ViewModel.StartGeneration();
        }
    }
}