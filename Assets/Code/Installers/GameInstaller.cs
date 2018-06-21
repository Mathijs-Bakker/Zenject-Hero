using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] private readonly Settings _settings = null;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            InstallPlayer();
            InstallLives();
            InstallLaser();
            InstallDynamitePool();
            
            InstallGameManager();
        }

        private void InstallPlayer()
        {
            Container.Bind<PlayerFacade>()
                .FromComponentInNewPrefab(_settings.PlayerPrefab)
                .UnderTransformGroup("Player")
                .AsSingle();
        }

        private void InstallLives()
        {
            Container.Bind<LivesCounter>().AsSingle();
        }

        private void InstallLaser()
        {
            Container.Bind<Laser>()
                .FromComponentInNewPrefab(_settings.LaserPrefab)
                .UnderTransformGroup("Player")
                .AsSingle();
        }

        private void InstallDynamitePool()
        {
            Container.Bind<Dynamite>().AsSingle();
            Container.BindMemoryPool<Dynamite, Dynamite.Pool>()
                .WithInitialSize(20)
                .FromComponentInNewPrefab(_settings.DynamitePrefab)
                .UnderTransformGroup("Dynamite");

            Container.Bind<DynamitesCounter>().AsSingle();
        }

        private void InstallGameManager()
        {
            Container.Bind<GameStateFactory>().AsSingle();

            Container.BindFactory<MenuState, MenuState.Factory>()
                .WhenInjectedInto<GameStateFactory>();

            Container.BindFactory<PlayState, PlayState.Factory>()
                .WhenInjectedInto<GameStateFactory>();
        }

        [Serializable]
        public class Settings
        {
            public GameObject PlayerPrefab;
            public GameObject LaserPrefab;
            public GameObject DynamitePrefab;
        }
    }
}