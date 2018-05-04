using Zenject;

namespace Code
{
    public class SpiderInstaller : MonoInstaller<SpiderInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SpiderModel>().AsSingle();
        }
    }
}