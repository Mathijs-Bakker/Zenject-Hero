#if !NOT_UNITY3D

using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject
{
    public class ResourceProvider : IProvider
    {
        readonly Type _resourceType;
        readonly string _resourcePath;

        public ResourceProvider(
            string resourcePath, Type resourceType)
        {
            _resourceType = resourceType;
            _resourcePath = resourcePath;
        }

        public Type GetInstanceType(InjectContext context)
        {
            return _resourceType;
        }

        public List<object> GetAllInstancesWithInjectSplit(
            InjectContext context, List<TypeValuePair> args, out Action injectAction)
        {
            Assert.IsEmpty(args);

            Assert.IsNotNull(context);

            var objects = Resources.LoadAll(_resourcePath, _resourceType).Cast<object>().ToList();

            Assert.That(!objects.IsEmpty(),
                "Could not find resource at path '{0}' with type '{1}'", _resourcePath, _resourceType);

            // Are there any resource types which can be injected?
            injectAction = null;
            return objects;
        }
    }
}

#endif


