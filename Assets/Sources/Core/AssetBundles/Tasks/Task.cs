using System;
using System.Collections;
using UnityEngine;

namespace Sources.Core.AssetBundles.Tasks
{
    public class Task : ITask
    {
        public TaskPriorityEnum Priority
        {
            get
            {
                return _taskPriority;
            }
        }
        private Action _feedback;
        private readonly TaskPriorityEnum _taskPriority;
        private readonly MonoBehaviour _coroutineHost;
        private readonly IEnumerator _taskAction;
        
        private Coroutine _coroutine;
        

        private Task(IEnumerator taskAction, TaskPriorityEnum priority)
        {
            _coroutineHost = CoroutineHostForTask.CoroutineHost;
            _taskPriority = priority;
            _taskAction = taskAction;
        }

        public static Task Create(IEnumerator taskAction, TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            return new Task(taskAction, priority);
        }


        public void Start()
        {
            if (_coroutine == null)
            {
                _coroutine = _coroutineHost.StartCoroutine(RunTask());
            }
        }

        public ITask Subscribe(Action feedback)
        {
            _feedback += feedback;

            return this;
        }

        public void Stop()
        {
            if (_coroutine != null)
            {
                _coroutineHost.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator RunTask()
        {
            yield return _taskAction;
            
            CallSubscribe();
        }
        
        private void CallSubscribe()
        {
            if (_feedback != null)
            {
                _feedback();
            }
        }
    }
}