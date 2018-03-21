using Zenject;

namespace Code
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        public override void InstallBindings()
        {
            InstallStartGameButton();
        }

        private void InstallStartGameButton()
        {
            Container.Bind<StartGameButton>().AsSingle();
        }
    }
}