using Zenject;

namespace Code
{
    public class ScoreInstaller : MonoInstaller<ScoreInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<UpdateScoreSignal>();

            Container.BindSignal<int, UpdateScoreSignal>()
                .To<ScoreManager>(x => x.UpdateScore)
                .FromComponentInHierarchy();
        }
    }
}