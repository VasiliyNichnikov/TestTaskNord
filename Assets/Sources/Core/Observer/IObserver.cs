namespace Sources.Core.Observer
{
    public interface IObserver
    {
        void SubscribeToHandler();
        void UnsubscribeToHandler();
    }
}