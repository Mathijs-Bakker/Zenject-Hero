using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class LevelSceneInstaller : MonoInstaller<LevelSceneInstaller>
    {
        [SerializeField] private Settings _settings;
        
        public override void InstallBindings()
        {
            InstallPlayer();
            InstallDynamitePool();
        }

        private void InstallPlayer()
        {
            Container.Bind<Player>().AsSingle();
        }

        private void InstallDynamitePool()
        {
            Container.Bind<Dynamite>().AsSingle();

            Container.BindMemoryPool<Dynamite, Dynamite.Pool>()
                .WithInitialSize(20)
                .FromComponentInNewPrefab(_settings.DynamitePrefab)
                .UnderTransformGroup("Dynamite");
        }

        [Serializable]
        private class Settings
        {
            public GameObject DynamitePrefab;
        }
    }
}