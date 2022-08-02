using UnityEngine;
using Sources.Infrastructure;
using Sources.Model;

namespace Sources.ViewModel
{
    public class BubbleViewModel: ViewModelBase
    {
        public readonly BindableProperty<Sprite> Sprite = new BindableProperty<Sprite>();
        public readonly BindableProperty<float> Speed = new BindableProperty<float>();
        public readonly BindableProperty<float> Size = new BindableProperty<float>();

        public void Initialization(Bubble bubble)
        {
            Sprite.Value = bubble.Sprite;
            Speed.Value = bubble.Speed;
            Size.Value = bubble.Size;
        }
    }
}

