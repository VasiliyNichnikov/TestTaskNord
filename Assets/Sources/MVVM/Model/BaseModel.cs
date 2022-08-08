using System;

namespace Sources.MVVM.Model
{
    public abstract class BaseModel
    {
        private Action _changed;

        public virtual void UploadResources()
        {
            
        }
        
        public void Subscribe(Action action)
        {
            _changed += action;
        }

        public void Unsubscribe(Action action)
        {
            _changed -= action;
        }
        
        protected void ModelChanged()
        {
            _changed();
        }

    }
}