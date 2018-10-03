using System.Collections.Generic;
using CaveIn.Contracts;
using Code;
using UnityEngine;
using Zenject;

namespace Dynamite.Code
{
    public class Dynamite : MonoBehaviour
    {
        private const float Seconds = 1f;

        private readonly List<GameObject> _overlappedColliders = new List<GameObject>();

        private Pool _dynamitePool;
        private DynamitesActive _dynamitesActive;

        private float _fuseTimer;

        [Inject]
        public void Construct(Pool dynamitePool, DynamitesActive dynamitesActive)
        {
            _dynamitePool = dynamitePool;
            _dynamitesActive = dynamitesActive;
        }

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

                    var damagableGo = go.GetComponent<Explodable>();
                    if (damagableGo != null)
                    {
                        damagableGo.BlowUp();
                        return;
                    }

                    var player = go.GetComponent<PlayerFacade>();
                    if (player != null) player.Die();
                }

            _dynamitesActive.IsDynamiteActive = false;
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