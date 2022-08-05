using Sources.Core.Generation;
using Sources.Core.MySprite;

namespace Sources.Model.Bubble
{
    public class BubbleRemovalModel: BaseModel
    {
        private readonly SampleSprite _sprite;
        private readonly ICreatedBubble _createdBubble;
        
        public BubbleRemovalModel(SampleSprite sprite, ICreatedBubble createdBubble)
        {
            _sprite = sprite;
            _createdBubble = createdBubble;
        }

        public override void OnDestroy()
        {
            _createdBubble.Unsubscribe(_sprite);
        }
    }
}