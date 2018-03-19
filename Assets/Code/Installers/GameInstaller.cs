using System;
using Zenject;

namespace Code
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] private Settings _settings;
        
        public override void InstallBindings()
        {
            InstallPlayer();
        }

        private void InstallPlayer()
        {
//            throw new System.NotImplementedException();
        }

        [Serializable]
        public class Settings
        {
            
        }
    }
}