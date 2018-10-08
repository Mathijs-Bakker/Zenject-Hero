using System;
using Code;
using UnityEngine;
using Zenject;

namespace Dynamite.Code.Installers
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
            Container.Bind<Dynamite>().AsSingle();

            Container.BindMemoryPool<Dynamite, Dynamite.Pool>()
                .WithInitialSize(20)
                .FromComponentInNewPrefab(_settings.DynamitePrefab)
                .UnderTransformGroup("Dynamite");

            Container.Bind<DynamitesActive>().AsSingle();
            Container.Bind<DynamitesCounter>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public GameObject DynamitePrefab;
        }
    }
}