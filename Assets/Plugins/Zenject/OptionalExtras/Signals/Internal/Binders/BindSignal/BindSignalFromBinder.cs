using System;
using ModestTree;

namespace Zenject
{
    public class BindSignalFromBinder<TObject, TSignal>
        where TSignal : ISignal
    {
        readonly BindFinalizerWrapper _finalizerWrapper;
        readonly Func<TObject, Action<TSignal>> _methodGetter;
        readonly DiContainer _container;

        public BindSignalFromBinder(
            BindFinalizerWrapper finalizerWrapper, Func<TObject, Action<TSignal>> methodGetter,
            DiContainer container)
        {
            _finalizerWrapper = finalizerWrapper;
            _methodGetter = methodGetter;
            _container = container;
        }

        public SignalCopyBinder FromResolve()
        {
            return From(x => x.FromResolve().AsCached());
        }

        public SignalCopyBinder From(Action<ConcreteBinderGeneric<TObject>> objectBindCallback)
        {
            Assert.IsNull(_finalizerWrapper.SubFinalizer);
            _finalizerWrapper.SubFinalizer = new NullBindingFinalizer();

            var objectLookupId = Guid.NewGuid();
            var objectBindInfo = new BindInfo();

            objectBindCallback(
                _container.Bind<TObject>(
                    objectBindInfo,
                    // Very important here that we call StartBinding with false otherwise our signal
                    // binding will be finalized early
                    _container.StartBinding(null, false)).WithId(objectLookupId));

            var wrapperBindInfo = new BindInfo();

            _container.Bind<IDisposable>(wrapperBindInfo)
                .To<SignalCallbackWithLookupWrapper<TObject, TSignal>>()
                .AsCached()
                .WithArguments(_methodGetter, objectLookupId)
                .NonLazy();

            // Make sure if they use one of the Copy/Move methods that it applies to both bindings
            return new SignalCopyBinder(wrapperBindInfo, objectBindInfo);
        }
    }
}
