using Sources.Core.MyRx;
using Sources.MVVM.Model.MyText;
using UnityEngine;

namespace Sources.MVVM.ViewModel.MyText
{
    public class TextViewModel: BaseViewModel<TextModel>
    {
        private readonly ReactiveProperty<Font> _font = new ReactiveProperty<Font>();
        
        public TextViewModel(TextModel model) : base(model)
        {
        }

        protected override void OnChanged()
        {
            _font.Value = Model.Font;
        }
        
        public IReactiveProperty<Font> GetFont()
        {
            return _font;
        }
    }
}