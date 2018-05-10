using Zenject;

namespace Code
{
    public class LightInstaller : MonoInstaller<LightInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<LightsOutSignal>();

            Container.BindSignal<LightsOutSignal>()
                .To<LightSwitcher>(x => x.SwitchLight)
                .FromComponentInHierarchy();
        }
    }
}