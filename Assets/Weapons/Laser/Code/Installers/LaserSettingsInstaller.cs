using System;
using UnityEngine;
using Zenject;

namespace Laser.Code.Installers
{
    [CreateAssetMenu(fileName = "LaserSettings", menuName = "Scriptable Objects/LaserSettingsInstaller")]
    public class LaserSettingsInstaller : ScriptableObjectInstaller<LaserSettingsInstaller>
    {
        public LaserPrefabInstaller.Settings LaserPrefabInstaller;
        public LaserSettings Laser;
        
        [Serializable]
        public class LaserSettings
        {
            public Laser.Settings Damage;
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(LaserPrefabInstaller).IfNotBound();
            Container.BindInstance(Laser.Damage);
        }
    }
}