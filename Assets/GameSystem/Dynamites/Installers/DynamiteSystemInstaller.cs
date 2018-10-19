using Zenject;

namespace GameSystem.Dynamites.Installers
{
    public class DynamiteSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DynamitesCount>().AsSingle();
            Container.BindInterfacesAndSelfTo<DynamitesController>().AsSingle();

            InstallSignals();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<NewDynamiteActivatedSignal>();
            Container.BindSignal<NewDynamiteActivatedSignal>()
                .ToMethod<DynamitesController>(x => x.NewActiveDynamite)
                .FromResolve();

            Container.DeclareSignal<DynamiteExplodedSignal>();
            Container.BindSignal<DynamiteExplodedSignal>()
                .ToMethod<DynamitesController>(x => x.DynamiteExploded)
                .FromResolve();
        }
    }
}