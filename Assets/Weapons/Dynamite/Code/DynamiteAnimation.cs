using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code
{
    public class DynamiteAnimation : ITickable
    {
        private readonly Animator _animator;
        private readonly DynamiteModel _dynamiteModel;

        public DynamiteAnimation(Animator animator, DynamiteModel dynamiteModel)
        {
            _animator = animator;
            _dynamiteModel = dynamiteModel;
        }
        
        private static readonly int IsExploding = Animator.StringToHash("IsExploding");
        public bool IsFinished { get; private set; }
        
        public void Tick()
        {
            if(!_dynamiteModel.IsExploding) return;
            Explode();
            
            if(!IsFinished) return;
            Reset();
        }

        private void Explode()
        {
            _animator.SetBool(IsExploding, true);
        } 
        
        public void AnimationFinished()
        {
            IsFinished = true;
            _dynamiteModel.HasFinished = true;
        }

        private void Reset()
        {
            _animator.SetBool(IsExploding, false);
            IsFinished = false;
        }

    }
}