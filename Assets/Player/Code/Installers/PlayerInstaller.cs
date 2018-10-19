using System;
using Player.Code.Signals;
using UnityEngine;
using Zenject;

namespace Player.Code.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Settings settings;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle()
                .WithArguments(
                    settings.rigidbody2D,
                    settings.spriteRenderer);

            Container.Bind<PlayerSpawner>().AsSingle();
            Container.Bind<PlayerDeathHandler>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();
            Container.Bind<PlayerPhysics>().AsSingle().WithArguments(settings.rigidbody2D);
            Container.Bind<PlayerAnimationStates>().AsSingle().WithArguments(settings.animator);
//            Container.Bind<PlayerCollision>().AsSingle();

            Container.BindInterfacesTo<PlayerAnimationController>().AsSingle();
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMovement>().AsSingle();
            Container.BindInterfacesTo<PlayerActionHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerGrounded>().AsSingle();

            InstallPlayerReadySignal();
        }

        private void InstallPlayerReadySignal()
        {
            Container.DeclareSignal<PlayerReadySignal>();
            Container.BindSignal<PlayerReadySignal>()
                .ToMethod<PlayerModel>(x => x.PlayerReady)
                .FromResolve();
        }
    }

    [Serializable]
    public class Settings
    {
        public Animator animator;
        public Rigidbody2D rigidbody2D;
        public SpriteRenderer spriteRenderer;
    }
}