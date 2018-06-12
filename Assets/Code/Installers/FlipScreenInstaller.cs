using Zenject;

namespace Code.FlipScreen
{
    public class FlipScreenInstaller : MonoInstaller<FlipScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayerMovedOutOfScreenSignal>();

            Container.Bind<FlipScreenManager>().AsSingle();

            Container.BindSignal<PlayerMovedOutOfScreenSignal>()
                .ToMethod<FlipScreenManager>((x, y) => x.FlipScreen(y.BorderPosition))
                .FromResolve();

//            Container.BindSignal<ScreenBorder, PlayerMovedOutOfScreenSignal>()
//                .To<FlipScreenManager>(x => x.FlipScreen)
//                .FromComponentInHierarchy();
        }
    }
}