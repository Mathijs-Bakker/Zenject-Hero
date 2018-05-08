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

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Yes");
            if (other.gameObject.GetComponent<PlayerFacade>())
            {
                _lightsOutSignal.Fire();
            }
        }
    }
}