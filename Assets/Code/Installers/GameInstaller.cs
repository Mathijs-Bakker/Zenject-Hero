using Zenject;

namespace Code
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameManager();
        }

        private void InstallGameManager()
        {
            Container.Bind<GameStateFactory>().AsSingle();
 
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayState>().AsSingle();
 
            Container.BindFactory<MenuState, MenuState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<PlayState, PlayState.Factory>().WhenInjectedInto<GameStateFactory>();
        }
    }
}