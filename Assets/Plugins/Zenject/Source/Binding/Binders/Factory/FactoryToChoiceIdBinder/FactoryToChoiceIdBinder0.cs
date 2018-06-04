using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject
{
    public class FactoryToChoiceIdBinder<TContract> : FactoryToChoiceBinder<TContract>
    {
        public FactoryToChoiceIdBinder(
            DiContainer container, BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(container, bindInfo, factoryBindInfo)
        {
        }

        public FactoryToChoiceBinder<TContract> WithId(object identifier)
        {
            BindInfo.Identifier = identifier;
            return this;
        }
    }
}


