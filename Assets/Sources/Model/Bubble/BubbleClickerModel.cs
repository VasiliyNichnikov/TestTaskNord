using Sources.Core.Generation;
using Sources.Core.MySprite;
using UnityEngine;

namespace Sources.Model.Bubble
{
    public class BubbleClickerModel: BaseModel
    {
        private readonly ICreatedBubble _createdBubble;
        private readonly SampleSprite _bubble;
        private int _numberOfClicks;

        private bool _isDestroy;
        
        public BubbleClickerModel(SampleSprite bubble, ICreatedBubble createdBubble, int numberOfClicks)
        {
            _bubble = bubble;
            _createdBubble = createdBubble;
            _numberOfClicks = numberOfClicks;
        }

        public override void Change()
        {
            Click();
            base.Change();
            
            if (_isDestroy)
                Object.Destroy(_bubble.gameObject);
        }

        private void Click()
        {
            _numberOfClicks--;
            if (_numberOfClicks < 0)
            {
                _createdBubble.Unsubscribe(_bubble);
                _isDestroy = true;
                return;
            }
        }
    }
}