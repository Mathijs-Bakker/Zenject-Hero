using System;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
//        [Inject] private readonly Settings _settings = null;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            InstallLives();
            
            InstallGameManager();
        }

        private void InstallLives()
        {
            Container.Bind<LivesCounter>().AsSingle();
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
//            public GameObject DynamitePrefab;
        }
    }
}