using System;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] private readonly Settings _settings = null;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            InstallLives();
//            InstallDynamitePool();
            
            InstallGameManager();
        }

        private void InstallLives()
        {
            Container.Bind<LivesCounter>().AsSingle();
        }

//        private void InstallDynamitePool()
//        {
//            Container.Bind<Dynamite.Code.Dynamite>().AsSingle();
//            
//            Container.BindMemoryPool<Dynamite.Code.Dynamite, Dynamite.Code.Dynamite.Pool>()
//                .WithInitialSize(20)
//                .FromComponentInNewPrefab(_settings.DynamitePrefab)
//                .UnderTransformGroup("Dynamite");
//
//            Container.Bind<DynamitesActive>().AsSingle();
//            Container.Bind<DynamitesCounter>().AsSingle();
//        }

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
//            public GameObject DynamitePrefab;
        }
    }
}