using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject
{
    public class MemoryPoolExpandBinder<TContract> : FactoryToChoiceIdBinder<TContract>
    {
        public MemoryPoolExpandBinder(
            DiContainer bindContainer, BindInfo bindInfo, FactoryBindInfo factoryBindInfo, MemoryPoolBindInfo poolBindInfo)
            : base(bindContainer, bindInfo, factoryBindInfo)
        {
            MemoryPoolBindInfo = poolBindInfo;

            ExpandByOneAtATime();
        }

        protected MemoryPoolBindInfo MemoryPoolBindInfo
        {
            get; private set;
        }

        public FactoryToChoiceIdBinder<TContract> ExpandByOneAtATime()
        {
            MemoryPoolBindInfo.ExpandMethod = PoolExpandMethods.OneAtATime;
            return this;
        }

        public FactoryToChoiceIdBinder<TContract> ExpandByDoubling()
        {
            MemoryPoolBindInfo.ExpandMethod = PoolExpandMethods.Double;
            return this;
        }
    }
}

