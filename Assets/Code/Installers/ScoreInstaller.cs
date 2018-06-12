using Zenject;

namespace Code
{
    public class ScoreInstaller : MonoInstaller<ScoreInstaller>
    {
        public override void InstallBindings()
        {
            SignalRootInstaller.Install(Container);
            
            Container.DeclareSignal<UpdateScoreSignal>();

            Container.Bind<ScoreManager>().AsSingle();

            Container.BindSignal<UpdateScoreSignal>()
                .ToMethod<ScoreManager>((x, n) => x.UpdateScore(n.ScorePoints))
                .FromResolve();
            
//            Container.BindSignal<int, UpdateScoreSignal>();

//            Container.DeclareSignal<UpdateScoreSignal>();


//            Container.DeclareSignal<UpdateScoreSignal>();
//
//            Container.BindSignal<int, UpdateScoreSignal>()
//                .To<ScoreManager>(x => x.UpdateScore)
//                .FromComponentInHierarchy();
        }
    }
//    SignalRootInstaller.Install(Container);

//    Container.DeclareSignal<UserJoinedSignal>();
//
//    Container.Bind<Greeter>().AsSingle();
//
//    Container.BindSignal<UserJoinedSignal>()
//    .ToMethod<Greeter>((x, s) => x.SayHello(s.Username)).FromResolve();
//
//    Container.BindInterfacesTo<GameInitializer>().AsSingle();
}