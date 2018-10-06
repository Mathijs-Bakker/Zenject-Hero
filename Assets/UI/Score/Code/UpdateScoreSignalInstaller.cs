using Zenject;

namespace UI.Score.Code
{
    public class UpdateScoreSignalInstaller : MonoInstaller<UpdateScoreSignalInstaller>
    {
        public override void InstallBindings()
        {
            
            Container.DeclareSignal<UpdateScoreSignal>();

            Container.BindSignal<UpdateScoreSignal>()
                .ToMethod<Score>((x, n) => x.AddPoints(n.ScorePoints))
                .FromResolve();
        }
    }
}