using Code.Signals;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Lamp : MonoBehaviour
    {
        private LightsOutSignal _lightsOutSignal;

        [Inject]
        public void Construct(LightsOutSignal lightsOutSignal)
        {
            _lightsOutSignal = lightsOutSignal;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerFacade>())
            {
                _lightsOutSignal.Fire();
            }
        }
    }
}