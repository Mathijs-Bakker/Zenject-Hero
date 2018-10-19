using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code.AnimationEvents
{
    public class DynamiteAnimationFinishedEvent : MonoBehaviour
    {
        [Inject] private readonly DynamiteAnimation _dynamiteAnimation = null;

        public void AnimationFinishedEvent()
        {
            _dynamiteAnimation.AnimationFinished();
        }
    }
}