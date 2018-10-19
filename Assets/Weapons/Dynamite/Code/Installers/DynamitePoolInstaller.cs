using System;
using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code.Installers
{
    public class DynamitePoolInstaller : MonoInstaller
    {
        [Inject] private readonly Settings _settings = null;

        public override void InstallBindings()
        {
            InstallDynamitePool();
        }

        private void InstallDynamitePool()
        {
            Container.BindMemoryPool<DynamiteController, DynamiteController.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(_settings.dynamitePrefab)
                .UnderTransformGroup("Dynamite");
        }

        [Serializable]
        public class Settings
        {
            public GameObject dynamitePrefab;
        }
    }
}