using System;
using System.Collections.Generic;

namespace Zenject
{
    public class FactoryFromBinder<TParam1, TParam2, TContract> : FactoryFromBinderBase
    {
        public FactoryFromBinder(
            DiContainer container, BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(container, typeof(TContract), bindInfo, factoryBindInfo)
        {
        }

        public ConditionCopyNonLazyBinder FromMethod(Func<DiContainer, TParam1, TParam2, TContract> method)
        {
            ProviderFunc =
                (container) => new MethodProviderWithContainer<TParam1, TParam2, TContract>(method);

            return this;
        }

        // Shortcut for FromIFactory and also for backwards compatibility
        public ConditionCopyNonLazyBinder FromFactory<TSubFactory>()
            where TSubFactory : IFactory<TParam1, TParam2, TContract>
        {
            return FromIFactory(x => x.To<TSubFactory>().AsCached());
        }

        public ArgConditionCopyNonLazyBinder FromIFactory(
            Action<ConcreteBinderGeneric<IFactory<TParam1, TParam2, TContract>>> factoryBindGenerator)
        {
            Guid factoryId;
            factoryBindGenerator(
                CreateIFactoryBinder<IFactory<TParam1, TParam2, TContract>>(out factoryId));

            ProviderFunc =
                (container) => { return new IFactoryProvider<TParam1, TParam2, TContract>(container, factoryId); };

            return new ArgConditionCopyNonLazyBinder(BindInfo);
        }

        public FactorySubContainerBinder<TParam1, TParam2, TContract> FromSubContainerResolve()
        {
            return FromSubContainerResolve(null);
        }

        public FactorySubContainerBinder<TParam1, TParam2, TContract> FromSubContainerResolve(object subIdentifier)
        {
            return new FactorySubContainerBinder<TParam1, TParam2, TContract>(
                BindContainer, BindInfo, FactoryBindInfo, subIdentifier);
        }
    }
}
