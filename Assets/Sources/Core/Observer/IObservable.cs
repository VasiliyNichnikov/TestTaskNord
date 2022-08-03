using System;

namespace Sources.Core.Observer
{
    public interface IObservable
    {
        IDisposable Subscribe(IObserver observer);
    }
}