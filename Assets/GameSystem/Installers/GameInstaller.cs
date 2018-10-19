using UI.Lives.Code;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            InstallLives();
        }

        private void InstallLives()
        {
            Container.Bind<LivesCounter>().AsSingle();
        }
    }
}