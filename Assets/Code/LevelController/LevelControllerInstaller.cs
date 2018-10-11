using Zenject;

namespace Code.LevelController
{
    public class LevelControllerInstaller : MonoInstaller<LevelControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
        }
    }
}