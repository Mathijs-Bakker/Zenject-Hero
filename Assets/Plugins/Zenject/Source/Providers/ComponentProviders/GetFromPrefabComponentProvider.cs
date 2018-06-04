#if !NOT_UNITY3D

using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject
{
    public class GetFromPrefabComponentProvider : IProvider
    {
        readonly IPrefabInstantiator _prefabInstantiator;
        readonly Type _componentType;

        // if concreteType is null we use the contract type from inject context
        public GetFromPrefabComponentProvider(
            Type componentType,
            IPrefabInstantiator prefabInstantiator)
        {
            _prefabInstantiator = prefabInstantiator;
            _componentType = componentType;
        }

        public Type GetInstanceType(InjectContext context)
        {
            return _componentType;
        }

        public List<object> GetAllInstancesWithInjectSplit(
            InjectContext context, List<TypeValuePair> args, out Action injectAction)
        {
            Assert.IsNotNull(context);

            var gameObject = _prefabInstantiator.Instantiate(args, out injectAction);

            // NOTE: Need to set includeInactive to true here, because prefabs are always
            // instantiated as disabled until injection occurs, so that Awake / OnEnabled is executed
            // after injection has occurred
            var allComponents = gameObject.GetComponentsInChildren(_componentType, true);

            Assert.That(allComponents.Length >= 1,
                "Expected to find at least one component with type '{0}' on prefab '{1}'",
                _componentType, _prefabInstantiator.GetPrefab().name);

            return allComponents.Cast<object>().ToList();
        }
    }
}

#endif
