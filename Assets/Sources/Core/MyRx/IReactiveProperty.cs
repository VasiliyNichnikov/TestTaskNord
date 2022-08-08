namespace Sources.Core.MyRx
{
    public interface IReactiveProperty<T>: IEventProvider
    {
        T Value { get; }
    }
}