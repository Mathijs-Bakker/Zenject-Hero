using System;
using Code;
using Enemies.Contracts;
using UnityEngine;
using Zenject;

namespace Laser.Code
{
    public class Laser : MonoBehaviour
    {
        private PlayerFacade _player;

        private Settings _settings;
        private SpriteRenderer _spriteRenderer;

        public bool IsFiring { private get; set; }

        [Inject]
        public void Construct(
            Settings settings,
            PlayerFacade player)
        {
            _settings = settings;
            _player = player;
        }

        private void Start()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        private void Update()
        {
            UpdateLaser();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsFiring) return;

            var enemy = other.GetComponent<Enemy>();
            if (enemy != null) enemy.ReceiveDamage(_settings.Damage);
            
            var damagableGo = other.GetComponent<Damageable>();
            if (damagableGo != null) damagableGo.ReceiveDamage(_settings.Damage);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!IsFiring) return;

            var enemy = other.GetComponent<Enemy>();
            if (enemy != null) enemy.ReceiveDamage(_settings.Damage);
            
            var damagableGo = other.GetComponent<Damageable>();
            if (damagableGo != null) damagableGo.ReceiveDamage(_settings.Damage);
            
        }

        private void UpdateLaser()
        {
            transform.rotation = _player.IsFacingLeft ? new Quaternion(0, 180f, 0, 0) : new Quaternion(0, 0, 0, 0);
            transform.position = _player.Position;
            _spriteRenderer.enabled = IsFiring;
        }

        [Serializable]
        public class Settings
        {
            public int Damage;
        }
    }
}