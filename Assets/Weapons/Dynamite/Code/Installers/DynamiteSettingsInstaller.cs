using System;
using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code.Installers
{
    [CreateAssetMenu(fileName = "DynamiteSettings", menuName = "Scriptable Objects/DynamiteSettingsInstaller")]
    public class DynamiteSettingsInstaller : ScriptableObjectInstaller<DynamiteSettingsInstaller>
    {
        public DynamitePoolInstaller.Settings dynamitePool;
        public FuseSettings fuse;

        public override void InstallBindings()
        {
            Container.BindInstance(dynamitePool).IfNotBound();
            Container.BindInstance(fuse.fuseTimer);
        }

        [Serializable]
        public class FuseSettings
        {
            public DynamiteFuse.Settings fuseTimer;
        }
    }
}