using System;
using ModestTree;

namespace Zenject
{
    public static class SignalExtensions
    {
        public static DeclareSignalRequireHandlerAsyncCopyBinder DeclareSignal<TSignal>(this DiContainer container)
            where TSignal : ISignal
        {
            var signalBindInfo = new SignalDeclarationBindInfo(typeof(TSignal));
            var bindInfo = new BindInfo();
            container.Bind<SignalDeclarationBindInfo>(bindInfo)
                .FromInstance(signalBindInfo).WhenInjectedInto<SignalBus>();
            return new DeclareSignalRequireHandlerAsyncCopyBinder(signalBindInfo, bindInfo);
        }

        public static BindSignalToBinder<TSignal> BindSignal<TSignal>(this DiContainer container)
            where TSignal : ISignal
        {
            return new BindSignalToBinder<TSignal>(container);
        }
    }
}
