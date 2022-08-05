using System;

namespace Sources.Model
{
    public abstract class BaseModel
    {
        private Action _changed;

        public virtual void Change()
        {
            // todo не самый лучший вариант реализации, особенно если будет много подписей на объект
            _changed();
        }

        public void Subscribe(Action action)
        {
            _changed += action;
        }

        public void Unsubscribe(Action action)
        {
            _changed -= action;
        }

        public void OnDestroy()
        {
            
        }
    }
}