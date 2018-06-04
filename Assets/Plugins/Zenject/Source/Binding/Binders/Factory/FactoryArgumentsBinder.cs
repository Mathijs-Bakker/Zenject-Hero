using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject
{
    public class FactoryArgumentsBinder : ArgConditionCopyNonLazyBinder
    {
        public FactoryArgumentsBinder(
            DiContainer container, BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(bindInfo)
        {
            FactoryBindInfo = factoryBindInfo;
            BindContainer = container;
        }

        protected DiContainer BindContainer
        {
            get; private set;
        }

        protected FactoryBindInfo FactoryBindInfo
        {
            get; private set;
        }

        // We use generics instead of params object[] so that we preserve type info
        // So that you can for example pass in a variable that is null and the type info will
        // still be used to map null on to the correct field
        public ArgConditionCopyNonLazyBinder WithFactoryArguments<T>(T param)
        {
            FactoryBindInfo.Arguments = InjectUtil.CreateArgListExplicit(param);
            return this;
        }

        public ArgConditionCopyNonLazyBinder WithFactoryArguments<TParam1, TParam2>(TParam1 param1, TParam2 param2)
        {
            FactoryBindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2);
            return this;
        }

        public ArgConditionCopyNonLazyBinder WithFactoryArguments<TParam1, TParam2, TParam3>(
            TParam1 param1, TParam2 param2, TParam3 param3)
        {
            FactoryBindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3);
            return this;
        }

        public ArgConditionCopyNonLazyBinder WithFactoryArguments<TParam1, TParam2, TParam3, TParam4>(
            TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
        {
            FactoryBindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3, param4);
            return this;
        }

        public ArgConditionCopyNonLazyBinder WithFactoryArguments<TParam1, TParam2, TParam3, TParam4, TParam5>(
            TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
        {
            FactoryBindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3, param4, param5);
            return this;
        }

        public ArgConditionCopyNonLazyBinder WithFactoryArguments<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6)
        {
            FactoryBindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3, param4, param5, param6);
            return this;
        }

        public ArgConditionCopyNonLazyBinder WithFactoryArguments(object[] args)
        {
            FactoryBindInfo.Arguments = InjectUtil.CreateArgList(args);
            return this;
        }

        public ArgConditionCopyNonLazyBinder WithFactoryArgumentsExplicit(IEnumerable<TypeValuePair> extraArgs)
        {
            FactoryBindInfo.Arguments = extraArgs.ToList();
            return this;
        }
    }
}
