using Zenject;

namespace Code.Installers
{
    public class LevelSceneInstaller : MonoInstaller<LevelSceneInstaller>
    {
        public override void InstallBindings()
        {
            InstallPlayer();
        }

        private void InstallPlayer()
        {
            Container.Bind<Player>().AsSingle();
        }
    }
}