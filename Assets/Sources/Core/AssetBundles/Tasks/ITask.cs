using System;

namespace Sources.Core.AssetBundles.Tasks
{
    public interface ITask
    {
        TaskPriorityEnum Priority { get; }

        void Start();
        ITask Subscribe(Action feedback);
        void Stop();
    }
}