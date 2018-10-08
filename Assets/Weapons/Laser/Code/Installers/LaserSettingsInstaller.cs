using System;
using UnityEngine;
using Zenject;

namespace Laser.Code.Installers
{
    [CreateAssetMenu(fileName = "LaserSettings", menuName = "Scriptable Objects/LaserSettingsInstaller")]
    public class LaserSettingsInstaller : ScriptableObjectInstaller<LaserSettingsInstaller>
    {
        public LaserSettings Laser;
        public LaserPrefabInstaller.Settings LaserPrefabInstaller;

        public override void InstallBindings()
        {
            Container.BindInstance(LaserPrefabInstaller).IfNotBound();
            Container.BindInstance(Laser.Damage);
        }

        [Serializable]
        public class LaserSettings
        {
            public Laser.Settings Damage;
        }
    }
}