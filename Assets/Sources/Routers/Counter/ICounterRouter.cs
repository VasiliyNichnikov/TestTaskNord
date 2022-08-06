namespace Sources.Routers.Counter
{
    public interface ICounterRouter
    {
        void CreateCounter();

        void UpdateCounter(int plus);
    }
}