using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject
{
    public class FactoryFromBinder<TContract> : FactoryFromBinderBase
    {
        public FactoryFromBinder(
            DiContainer container, BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(container, typeof(TContract), bindInfo, factoryBindInfo)
        {
        }

        public ConditionCopyNonLazyBinder FromResolveGetter<TObj>(Func<TObj, TContract> method)
        {
            return FromResolveGetter<TObj>(null, method);
        }

        public ConditionCopyNonLazyBinder FromResolveGetter<TObj>(
            object subIdentifier, Func<TObj, TContract> method)
        {
            return FromResolveGetter<TObj>(subIdentifier, method, InjectSources.Any);
        }

        public ConditionCopyNonLazyBinder FromResolveGetter<TObj>(
            object subIdentifier, Func<TObj, TContract> method, InjectSources source)
        {
            FactoryBindInfo.ProviderFunc =
                (container) => new GetterProvider<TObj, TContract>(subIdentifier, method, container, source, false);

            return this;
        }

        public ConditionCopyNonLazyBinder FromMethod(Func<DiContainer, TContract> method)
        {
            ProviderFunc =
                (container) => new MethodProviderWithContainer<TContract>(method);

            return this;
        }

        // Shortcut for FromIFactory and also for backwards compatibility
        public ArgConditionCopyNonLazyBinder FromFactory<TSubFactory>()
            where TSubFactory : IFactory<TContract>
        {
            return FromIFactory(x => x.To<TSubFactory>().AsCached());
        }

        public ArgConditionCopyNonLazyBinder FromIFactory(
            Action<ConcreteBinderGeneric<IFactory<TContract>>> factoryBindGenerator)
        {
            Guid factoryId;
            factoryBindGenerator(
                CreateIFactoryBinder<IFactory<TContract>>(out factoryId));

            ProviderFunc =
                (container) => { return new IFactoryProvider<TContract>(container, factoryId); };

            return new ArgConditionCopyNonLazyBinder(BindInfo);
        }

        public FactorySubContainerBinder<TContract> FromSubContainerResolve()
        {
            return FromSubContainerResolve(null);
        }

        public FactorySubContainerBinder<TContract> FromSubContainerResolve(object subIdentifier)
        {
            return new FactorySubContainerBinder<TContract>(
                BindContainer, BindInfo, FactoryBindInfo, subIdentifier);
        }

#if !NOT_UNITY3D

        public ConditionCopyNonLazyBinder FromComponentInHierarchy()
        {
            BindingUtil.AssertIsInterfaceOrComponent(ContractType);

            return FromMethod((container) =>
                {
                    var matches = container.Resolve<Context>().GetRootGameObjects()
                        .SelectMany(x => x.GetComponentsInChildren<TContract>()).ToList();

                    Assert.That(!matches.IsEmpty(),
                        "Found zero matches when looking up type '{0}' using FromComponentInHierarchy for factory", ContractType);

                    Assert.That(matches.Count() == 1,
                        "Found multiple matches when looking up type '{0}' using FromComponentInHierarchy for factory.  Only expected to find one!", ContractType);

                    return matches.Single();
                });
        }
#endif
    }
}
