using System.Collections;
using System.Collections.Generic;

namespace Sources.Core.AssetBundles.Tasks
{
    public class TaskManager
    {
        public ITask CurrentTask
        {
            get
            {
                return _currentTask;
            }
        }

        private ITask _currentTask;
        private readonly List<ITask> _tasks = new List<ITask>();

        public ITask AddTask(IEnumerator taskAction, TaskPriorityEnum taskPriority = TaskPriorityEnum.Default)
        {
            var task = Task.Create(taskAction, taskPriority);

            ProcessingAddedTask(task, taskPriority);

            return task;
        }

        public void Break()
        {
            if (_currentTask != null)
            {
                _currentTask.Stop();
            }
        }

        public void Restore()
        {
            TaskQueueProcessing();
        }

        public void Clear()
        {
            Break();
            
            _tasks.Clear();
        }

        private void ProcessingAddedTask(ITask task, TaskPriorityEnum taskPriority)
        {
            switch (taskPriority)
            {
                case TaskPriorityEnum.Default:
                    _tasks.Add(task);
                    break;
                case TaskPriorityEnum.High:
                    _tasks.Insert(0, task);
                    break;
                case TaskPriorityEnum.Interrupt:
                    if (_currentTask != null && _currentTask.Priority != TaskPriorityEnum.Interrupt)
                        _currentTask.Stop();
                    _currentTask = task;
                    task.Start();
                    break;
            }

            if (_currentTask == null)
            {
                _currentTask = GetNextTask();

                if (_currentTask != null)
                {
                    _currentTask.Start();
                }
            }
        }

        private void TaskQueueProcessing()
        {
            _currentTask = GetNextTask();

            if (_currentTask != null)
                _currentTask.Start();
        }

        private ITask GetNextTask()
        {
            if (_tasks.Count > 0)
            {
                var returnValue = _tasks[0];
                _tasks.RemoveAt(0);

                return returnValue;
            }
            return null;
        }
    }
}