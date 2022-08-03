using UnityEngine;

namespace Sources.Model.Bubble
{
    public class BubbleClickerModel: BaseModel
    {
        public Sprite Sprite { get; private set; }
        private readonly Sprite[] _stages;

        private int _numberOfClicks;
        
        public BubbleClickerModel(Sprite defaultSprite, Sprite[] stages)
        {
            Sprite = defaultSprite;
            _stages = stages;
            _numberOfClicks = stages.Length;
        }

        public override void Change()
        {
            Click();
            base.Change();
        }

        private void Click()
        {
            _numberOfClicks--;
            if (_numberOfClicks < 0)
            {
                MonoBehaviour.print("Лопаем шарик");
                return;
            }
            
            MonoBehaviour.print("Нажатие на шар");
            Sprite = _stages[_numberOfClicks];
        }
    }
}