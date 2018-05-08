using Code.Signals;
using Zenject;

namespace Code.Installers
{
    public class LightInstaller : MonoInstaller<LightInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<LightsOutSignal>();
        }
    }
}