using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Dynamite : MonoBehaviour
    {
        [Inject] private Pool _dynamitePool;

        private float _detonationTimer;
        private const float Seconds = 1f;

        private bool _isExploding;

        private void Start()
        {
            _detonationTimer = Seconds;
        }

        private void Update()
        {
            Debug.Log(_detonationTimer);
            Debug.Log(_inDamageRange.Count);
            _detonationTimer -= Time.deltaTime;
            
            if (_detonationTimer < 0)
            {
                Explode();
            }
        }

        private void Explode()
        {
            foreach (var gO in _inDamageRange)
            {
                Debug.Log(gO.name);
                
                if (gO.GetComponent(typeof(IDamageable)))
                {
                    Debug.Log("Whoot");
                    _inDamageRange.Remove(gO);
                    Destroy(gO);
                }
            }
            _dynamitePool.Despawn(this);
        }

        private List<GameObject> _inDamageRange = new List<GameObject>();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _inDamageRange.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _inDamageRange.Remove(other.gameObject);
        }


//        private void OnTriggerEnter2D(Collider2D other)
//        {
//            if (_isExploding)
//            {
//                Debug.Log(other.name);
//                var damageable = other.gameObject.GetComponent<CaveIn>();
//                if (damageable != null) damageable.BlowUp();
//                
//                _dynamitePool.Despawn(this);
//            }
//        }

        public class Pool : MonoMemoryPool<Dynamite>
        {
            protected override void Reinitialize(Dynamite dynamite)
            {
                dynamite._isExploding = false;
                dynamite._detonationTimer = Seconds;
                dynamite._inDamageRange.Clear();
            }
        }
    }
}
