namespace Sources.Infrastructure
{
    public abstract class ViewModelBase
    {
        private bool _isInitialized;
        
        public virtual void OnStartReveal()
        {
            if (_isInitialized == false)
            {
                OnInitialize();
                _isInitialized = true;
            }
        }
        
        public virtual void OnDestroy()
        {

        }
        
        protected virtual void OnInitialize()
        {

        }
    }
}
