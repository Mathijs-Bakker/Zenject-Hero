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
                .UnderTransform(ParentGetter);
        }

        private string parentGO = "Dynamite HUD";
        private Transform ParentGetter(InjectContext arg)
        {
            var go = GameObject.Find(parentGO);

            if (go != null) return go.transform;

            Debug.LogError("::: GameObject not found! :::\n" +
                           "Failed to find: " + parentGO);
            
            return transform;
        }
    }
}