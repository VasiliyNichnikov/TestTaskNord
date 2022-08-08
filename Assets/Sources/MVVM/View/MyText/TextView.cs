using Sources.Core.Binder;
using Sources.MVVM.ViewModel.MyText;
using UnityEngine.UI;

namespace Sources.MVVM.View.MyText
{
    public class TextView: Subscriber<TextViewModel>
    {
        private Text _text;
        
        public override void Init(TextViewModel model)
        {
            base.Init(model);
            SubscribeGameObject(ViewModel.GetFont(), font => _text.font = font);
        }
        
        private void Awake()
        {
            _text = GetComponent<Text>();
        }
    }
}