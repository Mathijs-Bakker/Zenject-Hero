using Zenject;

namespace Code.LightController
{
    public class LightsOffSignalInstaller : MonoInstaller<LightsOffSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<LightsOffSignal>();

            Container.BindSignal<LightsOffSignal>()
                .ToMethod<LightController>(x => x.TurnOffLightInCurrentScreen)
                .FromResolve();
        }
    }
}