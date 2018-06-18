using System;
using System.Collections.Generic;
#if !NOT_UNITY3D
using UnityEngine;
#endif
using ModestTree;

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

        public ArgConditionCopyNonLazyBinder FromPoolableMemoryPool<TContractAgain>(
            Action<MemoryPoolInitialSizeMaxSizeBinder<TContractAgain>> poolBindGenerator)
            // Unfortunately we have to pass the same contract in again to satisfy the generic
            // constraints below
            where TContractAgain : IPoolable<TParam1, IMemoryPool>
        {
            return FromPoolableMemoryPool<TContractAgain, PoolableMemoryPool<TParam1, IMemoryPool, TContractAgain>>(poolBindGenerator);
        }

        public ArgConditionCopyNonLazyBinder FromPoolableMemoryPool<TContractAgain, TMemoryPool>(
            Action<MemoryPoolInitialSizeMaxSizeBinder<TContractAgain>> poolBindGenerator)
            // Unfortunately we have to pass the same contract in again to satisfy the generic
            // constraints below
            where TContractAgain : IPoolable<TParam1, IMemoryPool>
            where TMemoryPool : MemoryPool<TParam1, IMemoryPool, TContractAgain>
        {
            Assert.IsEqual(typeof(TContractAgain), typeof(TContract));

            // Use a random ID so that our provider is the only one that can find it and so it doesn't
            // conflict with anything else
            var poolId = Guid.NewGuid();

            // Important to use NoFlush otherwise the binding will be finalized early
            var binder = BindContainer.BindMemoryPoolCustomInterfaceNoFlush<TContractAgain, TMemoryPool, TMemoryPool>().WithId(poolId);

            // Always make it non lazy by default in case the user sets an InitialSize
            binder.NonLazy();

            poolBindGenerator(binder);

            ProviderFunc =
                (container) => { return new PoolableMemoryPoolProvider<TParam1, TContractAgain, TMemoryPool>(container, poolId); };

            return new ArgConditionCopyNonLazyBinder(BindInfo);
        }
    }
}
