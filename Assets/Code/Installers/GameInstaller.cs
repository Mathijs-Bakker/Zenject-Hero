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
        }

        private void InstallLives()
        {
            Container.Bind<LivesCounter>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
//            public GameObject DynamitePrefab;
        }
    }
}