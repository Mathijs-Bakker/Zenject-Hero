using Zenject;

namespace Code.LevelManager
{
    public class LevelControllerInstaller : MonoInstaller<LevelControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
        }
    }
}