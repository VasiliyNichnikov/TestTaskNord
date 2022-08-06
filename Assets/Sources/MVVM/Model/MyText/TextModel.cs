using UnityEngine;

namespace Sources.MVVM.Model.MyText
{
    public class TextModel: BaseModel
    {
        public Font Font { get; private set; }
        
        public void LoadFont(Font font)
        {
            Font = font;
            ModelChanged();
        }
    }
}