using System;

namespace Sources.Core.Tasks
{
    public interface ITask
    {
        TaskPriorityEnum Priority { get; }

        void Start();
        ITask Subscribe(Action feedback);
        void Stop();
    }
}