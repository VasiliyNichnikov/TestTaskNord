using Sources.Core.ObjectBubble;

namespace Sources.Core.Generation
{
    public interface ICreatedBubble
    {
        void Unsubscribe(SampleBubble bubble);
    }
}