using UnityEngine;
using Zenject;

namespace Code
{
    public class UIDynamiteInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject UIDynamitePrefab;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UIDynamiteManager>().AsSingle();
            Container.BindMemoryPool<UIDynamite, UIDynamite.Pool>()
                .WithInitialSize(6)
                .FromComponentInNewPrefab(UIDynamitePrefab)
                .UnderTransform(transform);
        }
    }
}