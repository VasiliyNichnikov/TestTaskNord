namespace Sources.Dependence.Counter
{
    public interface ICounterRouter
    {
        void CreateCounter();

        void UpdateCounter(int plus);
    }
}