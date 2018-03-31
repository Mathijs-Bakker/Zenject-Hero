using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Dynamite : MonoBehaviour
    {
        [Inject] private Pool _dynamitePool;
        
        private readonly List<GameObject> _overlappedGOs = new List<GameObject>();

        private float _fuseTimer;
        private const float Seconds = 1f;

        private Collider2D _collider;
        
        private void Start()
        {
            _fuseTimer = Seconds;
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            _fuseTimer -= Time.deltaTime;
            
            if (_fuseTimer <= 0)
            {
                Explode();
            }
        }

        private void Explode()
        {
            foreach (var go in _overlappedGOs)
            {
                Debug.Log(go.name);
                Debug.Log(_overlappedGOs.Count);
                if (go.GetComponent(typeof(Damageable)))
                {
                    var myVar = go.GetComponent<Damageable>();
//                    myVar.BlowUp();
                    myVar.BlowUp();
                    
                }
                
                Debug.Log(_overlappedGOs.Count);
                if (go.CompareTag("Player"))
                {
//                    var player = gO.gameObject.GetComponent(typeof(PlayerFacade));
//                    player.IsDead = true;
                }
            }
            _dynamitePool.Despawn(this);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _overlappedGOs.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _overlappedGOs.Remove(other.gameObject);
        }

        public class Pool : MonoMemoryPool<Dynamite>
        {
            protected override void Reinitialize(Dynamite dynamite)
            {
                dynamite._fuseTimer = Seconds;
                dynamite._overlappedGOs.Clear();
            }
        }
    }
}