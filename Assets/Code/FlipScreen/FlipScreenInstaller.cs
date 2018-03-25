using Zenject;

namespace Code.FlipScreen
{
    public class FlipScreenInstaller : MonoInstaller<FlipScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayerOutOfScreenSignal>();

            Container.BindSignal<ScreenBoundary, PlayerOutOfScreenSignal>()
                .To<FlipScreenManager>(x => x.LogEnum)
                .FromComponentInHierarchy();
        }
    }
   
}