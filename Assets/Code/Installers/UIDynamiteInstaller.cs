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
            Container.BindFactory<UIDynamite, UIDynamite.Factory>()
                .FromComponentInNewPrefab(UIDynamitePrefab)
                .UnderTransform(transform);
        }
    }
}