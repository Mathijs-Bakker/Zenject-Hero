using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class UILivesInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject UILifePrefab;

        [Inject] private LivesCounter.Settings _livesCounterSettings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UILivesManager>().AsSingle();

            Container.BindMemoryPool<UILife, UILife.Pool>()
                .WithInitialSize(_livesCounterSettings.TotalNumLives)
                .FromComponentInNewPrefab(UILifePrefab)
                .UnderTransform(transform);
        } 
    }
}