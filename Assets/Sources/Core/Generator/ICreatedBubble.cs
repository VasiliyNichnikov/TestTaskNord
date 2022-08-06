using Sources.Core.Bubble;

namespace Sources.Core.Generator
{
    public interface ICreatedBubble
    {
        void Unsubscribe(SampleBubble bubble);
    }
}