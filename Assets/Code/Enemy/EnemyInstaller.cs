using Zenject;

namespace Code
{
    public class EnemyInstaller : MonoInstaller<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<EnemyFacade, EnemyFacade.Factory>();
        }
    }
}