using System;

namespace Sources.Model
{
    public abstract class BaseModel
    {
        private Action _changed;

        protected void ModelChanged()
        {
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
    }
}