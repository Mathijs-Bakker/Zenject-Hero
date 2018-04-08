using UnityEngine;
using Zenject;

namespace Code
{
    public class ScoreInstaller : MonoInstaller<ScoreInstaller>
    {
        [SerializeField] private UIScore _uiScore;
        
        public override void InstallBindings()
        {
            Container.DeclareSignal<UpdateScoreSignal>();

            Container.BindSignal<int, UpdateScoreSignal>()
                .To<UIScore>(x => x.UpdateScore)
                .FromInstance(_uiScore);
        }
    }
}