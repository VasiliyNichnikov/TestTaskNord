using System;
using Sources.Core.Rx;

namespace Sources.Infrastructure
{
    public class ReactiveProperty<T> : IReactiveProperty<T>
    {
        public event Action OnChanged;

        public T Value
        {
            get { return _value; }
            set
            {
                if (Equals(_value, value) == false)
                {
                    _value = value;
                    if (OnChanged != null)
                    {
                        OnChanged.Invoke();
                    }
                }
            }
        }

        private T _value;


        public override string ToString()
        {
            return Value != null ? Value.ToString() : "null";
        }
    }
}