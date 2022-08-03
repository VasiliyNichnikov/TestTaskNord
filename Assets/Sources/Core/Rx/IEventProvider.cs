using System;

namespace Sources.Core.Rx
{
    public interface IEventProvider
    {
        event Action OnChanged;
    }
}