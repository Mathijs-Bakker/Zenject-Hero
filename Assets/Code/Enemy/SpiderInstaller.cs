using Zenject;

namespace Code
{
    public class EnemyInstaller : MonoInstaller<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SpiderModel>().AsSingle();
        }
    }
}