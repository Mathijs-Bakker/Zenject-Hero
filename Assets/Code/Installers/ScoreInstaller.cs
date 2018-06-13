using Zenject;

namespace Code
{
    public class ScoreInstaller : MonoInstaller<ScoreInstaller>
    {
        public override void InstallBindings()
        {
            
            Container.DeclareSignal<UpdateScoreSignal>();

            Container.BindSignal<UpdateScoreSignal>()
                .ToMethod<ScoreManager>((x, n) => x.UpdateScore(n.ScorePoints))
                .FromResolve();
        }
    }
}