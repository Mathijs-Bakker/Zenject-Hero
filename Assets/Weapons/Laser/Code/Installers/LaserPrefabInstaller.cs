using System;
using UnityEngine;
using Zenject;

namespace Laser.Code.Installers
{
    public class LaserPrefabInstaller : MonoInstaller<LaserPrefabInstaller>
    {
        [Inject] private readonly Settings _settings = null;
        
        public override void InstallBindings()
        {
            InstallLaser();
        }

        private void InstallLaser()
        {
            Container.Bind<Laser>()
                .FromComponentInNewPrefab(_settings.LaserPrefab)
                .UnderTransformGroup("Player")
                .AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public GameObject LaserPrefab;
        }
    }
}