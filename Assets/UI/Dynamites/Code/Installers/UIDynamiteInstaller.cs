using GameSystem.Dynamites;
using UnityEngine;
using Zenject;

namespace UI.Dynamites.Code.Installers
{
    public class UIDynamiteInstaller : MonoInstaller
    {
        [Inject] private DynamitesCount.Settings _dynamiteCounterSettings;

        [SerializeField] private GameObject UIDynamitePrefab;

        public override void InstallBindings()
        {
            Container.Bind<DynamitesCount>().AsSingle();
            
            Container.BindInterfacesTo<UIDynamitesManager>().AsSingle();

            Container.BindMemoryPool<UIDynamite, UIDynamite.Pool>()
                .WithInitialSize(_dynamiteCounterSettings.totalNumDynamites)
                .FromComponentInNewPrefab(UIDynamitePrefab)
                .UnderTransform(transform);
        }
    }
}