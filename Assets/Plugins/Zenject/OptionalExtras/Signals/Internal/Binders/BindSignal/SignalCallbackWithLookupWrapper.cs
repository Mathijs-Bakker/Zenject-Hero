using System;
using ModestTree;

namespace Zenject
{
    public class SignalCallbackWithLookupWrapper<TObject, TSignal> : IDisposable
    {
        readonly DiContainer _container;
        readonly SignalBus _signalBus;
        readonly Guid _lookupId;
        readonly Func<TObject, Action<TSignal>> _methodGetter;

        public SignalCallbackWithLookupWrapper(
            Func<TObject, Action<TSignal>> methodGetter,
            Guid lookupId,
            SignalBus signalBus,
            DiContainer container)
        {
            _container = container;
            _methodGetter = methodGetter;
            _signalBus = signalBus;
            _lookupId = lookupId;

            signalBus.Subscribe<TSignal>(OnSignalFired);
        }

        void OnSignalFired(TSignal signal)
        {
            _methodGetter(_container.ResolveId<TObject>(_lookupId))(signal);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<TSignal>(OnSignalFired);
        }
    }
}

