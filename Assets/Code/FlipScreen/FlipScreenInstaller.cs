using Zenject;

namespace Code.FlipScreen
{
    public class FlipScreenInstaller : MonoInstaller<FlipScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayerMovedOutOfScreenSignal>();

            Container.BindSignal<ScreenBorder, PlayerMovedOutOfScreenSignal>()
                .To<FlipScreenManager>(x => x.FlipScreen)
                .FromComponentInHierarchy();
        }
    }
}