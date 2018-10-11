using UnityEngine;
using Zenject;

namespace UI.Lives.Code.Installer
{
    public class UILivesInstaller : MonoInstaller
    {
        [Inject] private LivesCounter.Settings _livesCounterSettings;

        [SerializeField] private GameObject UILifePrefab;

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