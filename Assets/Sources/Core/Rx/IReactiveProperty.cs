namespace Sources.Core.Rx
{
    public interface IReactiveProperty<T>: IEventProvider
    {
        T Value { get; }
    }
}