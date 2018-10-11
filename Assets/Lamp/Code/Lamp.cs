using Code;
using Code.LightController;
using Player.Code;
using UnityEngine;
using Zenject;

namespace Lamp.Code
{
    public class Lamp : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus = null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<PlayerFacade>()) _signalBus.Fire(new LightsOffSignal());
        }
    }
}