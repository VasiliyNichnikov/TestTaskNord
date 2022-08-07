﻿using System.Collections;
using UnityEngine;

namespace Sources.Core.Tasks
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

        private readonly TaskPriorityEnum _taskPriority;
        private readonly MonoBehaviour _coroutineHost;
        private readonly IEnumerator _taskAction;
        
        private Coroutine _coroutine;
        

        private Task(IEnumerator taskAction, TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            _coroutineHost = TaskManagerObject.CoroutineHost();
            _taskPriority = priority;
            _taskAction = taskAction;
        }

        public static Task Create(IEnumerator taskAction, TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            return new Task(taskAction, priority);
        }


        public void Start()
        {
            if (_coroutine != null)
            {
                _coroutine = _coroutineHost.StartCoroutine(RunTask());
            }
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
        }
        
    }
}