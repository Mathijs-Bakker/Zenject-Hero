using System;
using ModestTree;

namespace Zenject
{
    public class SignalCallbackWrapper<TSignal> : IDisposable
        where TSignal : ISignal
    {
        readonly SignalBus _signalBus;
        readonly Action<TSignal> _action;

        public SignalCallbackWrapper(
            Action<TSignal> action,
            SignalBus signalBus)
        {
            _signalBus = signalBus;
            _action = action;

            signalBus.Subscribe<TSignal>(OnSignalFired);
        }

        void OnSignalFired(TSignal signal)
        {
            _action(signal);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<TSignal>(OnSignalFired);
        }
    }
}
