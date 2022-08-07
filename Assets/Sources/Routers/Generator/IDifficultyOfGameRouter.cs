namespace Sources.Routers.Generator
{
    public interface IDifficultyOfGameRouter
    {
        int CurrentNumberOfBubbles { get; }
        float CurrentSpeedUpOn { get; }

        void CheckDifficulty();
    }
}