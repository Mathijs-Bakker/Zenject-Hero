using System;
using ModestTree;

namespace Zenject
{
    public class BindSignalFromBinder<TObject, TSignal>
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

        public SignalCopyBinder FromNew()
        {
            return From(x => x.FromNew().AsCached());
        }

        public SignalCopyBinder From(Action<ConcreteBinderGeneric<TObject>> objectBindCallback)
        {
            Assert.IsNull(_finalizerWrapper.SubFinalizer);
            _finalizerWrapper.SubFinalizer = new NullBindingFinalizer();

            var objectLookupId = Guid.NewGuid();

            // Very important here that we use NoFlush otherwise the main binding will be finalized early
            var objectBinder = _container.BindNoFlush<TObject>().WithId(objectLookupId);

            objectBindCallback(objectBinder);

            var wrapperBinder = _container.Bind<IDisposable>()
                .To<SignalCallbackWithLookupWrapper<TObject, TSignal>>()
                .AsCached()
                .WithArguments(_methodGetter, objectLookupId)
                .NonLazy();

            var copyBinder = new SignalCopyBinder( wrapperBinder.BindInfo);
            // Make sure if they use one of the Copy/Move methods that it applies to both bindings
            copyBinder.AddCopyBindInfo(objectBinder.BindInfo);
            return copyBinder;
        }
    }
}
