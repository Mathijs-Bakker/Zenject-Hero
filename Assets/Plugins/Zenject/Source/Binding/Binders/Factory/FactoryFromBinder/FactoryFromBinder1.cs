using System;
using System.Collections.Generic;

namespace Zenject
{
    public class FactoryFromBinder<TParam1, TContract> : FactoryFromBinderBase
    {
        public FactoryFromBinder(
            DiContainer container, BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(container, typeof(TContract), bindInfo, factoryBindInfo)
        {
        }

        public ConditionCopyNonLazyBinder FromMethod(Func<DiContainer, TParam1, TContract> method)
        {
            ProviderFunc =
                (container) => new MethodProviderWithContainer<TParam1, TContract>(method);

            return this;
        }

        // Shortcut for FromIFactory and also for backwards compatibility
        public ConditionCopyNonLazyBinder FromFactory<TSubFactory>()
            where TSubFactory : IFactory<TParam1, TContract>
        {
            return FromIFactory(x => x.To<TSubFactory>().AsCached());
        }

        public ArgConditionCopyNonLazyBinder FromIFactory(
            Action<ConcreteBinderGeneric<IFactory<TParam1, TContract>>> factoryBindGenerator)
        {
            Guid factoryId;
            factoryBindGenerator(
                CreateIFactoryBinder<IFactory<TParam1, TContract>>(out factoryId));

            ProviderFunc =
                (container) => { return new IFactoryProvider<TParam1, TContract>(container, factoryId); };

            return new ArgConditionCopyNonLazyBinder(BindInfo);
        }

        public FactorySubContainerBinder<TParam1, TContract> FromSubContainerResolve()
        {
            return FromSubContainerResolve(null);
        }

        public FactorySubContainerBinder<TParam1, TContract> FromSubContainerResolve(object subIdentifier)
        {
            return new FactorySubContainerBinder<TParam1, TContract>(
                BindContainer, BindInfo, FactoryBindInfo, subIdentifier);
        }
    }
}
