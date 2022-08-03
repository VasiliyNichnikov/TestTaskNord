using UnityEngine;

namespace Sources.Model
{
    public class BubbleClickerModel: BaseModel
    {
        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
        private readonly Sprite[] _stages;
        
        private Sprite _sprite;
        private int _numberOfClicks;
        
        public BubbleClickerModel(Sprite defaultSprite, Sprite[] stages)
        {
            _sprite = defaultSprite;
            _stages = stages;
            _numberOfClicks = stages.Length;
        }

        public void ClickOnBubble()
        {
            _numberOfClicks--;
            MonoBehaviour.print("Нажатие на шар");
            _sprite = _stages[_numberOfClicks];
            
            if (_numberOfClicks == 0)
            {
                MonoBehaviour.print("Лопаем шарик");
            }

            Changed();
        }
        
        
    }
}