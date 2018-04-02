using UnityEngine;

namespace Code
{
    public class CaveIn : Damageable
    {
        [SerializeField] private int _health;

        private Collider2D _collider2D;
        
        public void Damage(int damageReceived)
        {
            _health -= damageReceived;
            if (_health <= 0)
            {
                BlowUp();
            }
        }

        public override void BlowUp()
        {
            Destroy(gameObject);
//            gameObject.SetActive(false);
//            _collider2D.enabled = false;
        }
    }
}