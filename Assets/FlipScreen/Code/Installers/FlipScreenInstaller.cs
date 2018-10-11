using FlipScreen.Code.Signals;
using Zenject;

namespace FlipScreen.Code.Installers
{
    public class FlipScreenInstaller : MonoInstaller<FlipScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayerMovedOutOfScreenSignal>();

            Container.BindSignal<PlayerMovedOutOfScreenSignal>()
                .ToMethod<FlipScreenManager>((x, y) => x.FlipScreen(y.BorderPosition))
                .FromResolve();
        }
    }
}