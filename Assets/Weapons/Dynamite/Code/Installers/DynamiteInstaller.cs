using System;
using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code.Installers
{
    public class DynamiteInstaller : MonoInstaller<DynamiteInstaller>
    {
        [SerializeField] private Settings settings;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<DynamiteModel>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<DynamiteDamageDealer>()
                .AsSingle()
                .WithArguments(settings.collider2D);

            Container
                .BindInterfacesAndSelfTo<DynamiteFuse>()
                .AsSingle();
            
            Container
                .Bind<DynamiteAnimation>()
                .AsSingle()
                .WithArguments(settings.animator);
        }

        [Serializable]
        public class Settings
        {
            public Animator animator;
            public Collider2D collider2D;
        }
    }
}