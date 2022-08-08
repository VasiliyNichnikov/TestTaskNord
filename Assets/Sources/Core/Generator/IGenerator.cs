using Sources.Core.Bubble;

namespace Sources.Core.Generator
{
    public interface IGenerator
    {
        void Unsubscribe(SampleBubble bubble, int numberScore);
    }
}