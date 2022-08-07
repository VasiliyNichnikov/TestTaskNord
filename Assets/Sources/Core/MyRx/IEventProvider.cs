using System;

namespace Sources.Core.MyRx
{
    public interface IEventProvider
    {
        event Action OnChanged;
    }
}