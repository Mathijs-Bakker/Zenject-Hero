using System;
using Code;
using UnityEngine;
using Zenject;

namespace Player.Code.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle()
                .WithArguments(
                    _settings.Rigidbody2D,
                    _settings.SpriteRenderer);

            Container.Bind<PlayerSpawner>().AsSingle();
            Container.Bind<PlayerDeathHandler>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();
            Container.Bind<PlayerPhysics>().AsSingle().WithArguments(_settings.Rigidbody2D);
            Container.Bind<PlayerAnimationStates>().AsSingle().WithArguments(_settings.Animator);
            Container.Bind<PlayerCollision>().AsSingle();

            Container.BindInterfacesTo<PlayerAnimatorHandler>().AsSingle();
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
        public Animator Animator;
        public Rigidbody2D Rigidbody2D;
        public SpriteRenderer SpriteRenderer;
    }
}