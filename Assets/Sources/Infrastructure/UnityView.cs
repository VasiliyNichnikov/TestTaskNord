using UnityEngine;

namespace Sources.Infrastructure
{
    public abstract class UnityView<T> : MonoBehaviour where T: ViewModelBase
    {
        protected readonly BinderProperty<T> Binder = new BinderProperty<T>();
        private readonly BindableProperty<T> _viewModelProperty = new BindableProperty<T>();

        private bool _isInitialized;
        
        public T BindingContext
        {
            get
            {
                return _viewModelProperty.Value;
            }
            set
            {
                if (_isInitialized == false)
                {
                    OnInitialize();
                    _isInitialized = true;
                }

                _viewModelProperty.Value = value;
            }
        }

        public void Reveal()
        {
            gameObject.SetActive(true);
            BindingContext.OnStartReveal();
        }
        
        protected virtual void OnInitialize()
        {
            print("Инициализация view");
            _viewModelProperty.OnValueChanged += OnBindingContextChanged;
        }
        
        // TO-DO разобраться для чего нужен
        public virtual void OnBindingContextChanged(T oldValue, T newValue)
        {
            Binder.Unbind(oldValue);
            Binder.Bind(newValue);
        }
    }

}
