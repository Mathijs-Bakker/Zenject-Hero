using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Dynamite : MonoBehaviour
    {
        private const float Seconds = 1f;

        private readonly List<GameObject> _overlappedColliders =
            new List<GameObject>();

        [Inject] private Pool _dynamitePool;

        private float _fuseTimer;

        private void Start()
        {
            _fuseTimer = Seconds;
        }

        private void Update()
        {
            _fuseTimer -= Time.deltaTime;

            if (_fuseTimer <= 0) Explode();
        }

        private void Explode()
        {
            if (_overlappedColliders.Count != 0)
                for (var i = _overlappedColliders.Count - 1; i > -1; i--)
                {
                    var go = _overlappedColliders[i];

                    var damagableGo = go.GetComponent<Damageable>();
                    if (damagableGo != null)
                    {
                        damagableGo.BlowUp();
                        return;
                    }

                    var player = go.GetComponent<PlayerFacade>();
                    if (player != null) player.Die();
                }

            _dynamitePool.Despawn(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _overlappedColliders.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _overlappedColliders.Remove(other.gameObject);
        }

        public class Pool : MonoMemoryPool<Dynamite>
        {
            protected override void Reinitialize(Dynamite dynamite)
            {
                dynamite._fuseTimer = Seconds;
                dynamite._overlappedColliders.Clear();
            }
        }
    }
}