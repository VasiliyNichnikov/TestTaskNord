using UnityEngine;

namespace Sources.MVVM.Model.MyText
{
    public class TextModel: BaseModel
    {
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                if (value != null)
                {
                    _font = value;
                    ModelChanged();
                }
            }
        }

        private Font _font;

        public TextModel()
        {
            
        }
        
        public TextModel(Font font)
        {
            _font = font;
        }
        
    }
}