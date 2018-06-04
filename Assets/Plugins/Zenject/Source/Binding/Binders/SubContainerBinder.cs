using System;
using ModestTree;

namespace Zenject
{
    public class SubContainerBinder
    {
        readonly BindInfo _bindInfo;
        readonly BindFinalizerWrapper _finalizerWrapper;
        readonly object _subIdentifier;
        readonly bool _resolveAll;

        public SubContainerBinder(
            BindInfo bindInfo,
            BindFinalizerWrapper finalizerWrapper,
            object subIdentifier, bool resolveAll)
        {
            _bindInfo = bindInfo;
            _finalizerWrapper = finalizerWrapper;
            _subIdentifier = subIdentifier;
            _resolveAll = resolveAll;

            // Reset in case the user ends the binding here
            finalizerWrapper.SubFinalizer = null;
        }

        protected IBindingFinalizer SubFinalizer
        {
            set { _finalizerWrapper.SubFinalizer = value; }
        }

        public ScopeConditionCopyNonLazyBinder ByInstaller<TInstaller>()
            where TInstaller : InstallerBase
        {
            return ByInstaller(typeof(TInstaller));
        }

        public ScopeConditionCopyNonLazyBinder ByInstaller(Type installerType)
        {
            Assert.That(installerType.DerivesFrom<InstallerBase>(),
                "Invalid installer type given during bind command.  Expected type '{0}' to derive from 'Installer<>'", installerType);

            SubFinalizer = new SubContainerInstallerBindingFinalizer(
                _bindInfo, installerType, _subIdentifier, _resolveAll);

            return new ScopeConditionCopyNonLazyBinder(_bindInfo);
        }

        public ScopeConditionCopyNonLazyBinder ByMethod(Action<DiContainer> installerMethod)
        {
            SubFinalizer = new SubContainerMethodBindingFinalizer(
                _bindInfo, installerMethod, _subIdentifier, _resolveAll);

            return new ScopeConditionCopyNonLazyBinder(_bindInfo);
        }

#if !NOT_UNITY3D

        public NameTransformScopeConditionCopyNonLazyBinder ByNewPrefab(UnityEngine.Object prefab)
        {
            BindingUtil.AssertIsValidPrefab(prefab);

            var gameObjectInfo = new GameObjectCreationParameters();

            SubFinalizer = new SubContainerPrefabBindingFinalizer(
                _bindInfo, gameObjectInfo, prefab, _subIdentifier, _resolveAll);

            return new NameTransformScopeConditionCopyNonLazyBinder(_bindInfo, gameObjectInfo);
        }

        public NameTransformScopeConditionCopyNonLazyBinder ByNewPrefabResource(string resourcePath)
        {
            BindingUtil.AssertIsValidResourcePath(resourcePath);

            var gameObjectInfo = new GameObjectCreationParameters();

            SubFinalizer = new SubContainerPrefabResourceBindingFinalizer(
                _bindInfo, gameObjectInfo, resourcePath, _subIdentifier, _resolveAll);

            return new NameTransformScopeConditionCopyNonLazyBinder(_bindInfo, gameObjectInfo);
        }
#endif
    }
}
