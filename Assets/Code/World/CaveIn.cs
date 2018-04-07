using UnityEngine;

namespace Code
{
    public class CaveIn : Damageable
    {
        [SerializeField] private int _health;

        public override void ReceiveDamage(int damage)
        {

            _health -= damage;

            if (_health <= 0)
            {
                BlowUp();
            }
        }

        public override void BlowUp()
        {
            Destroy(gameObject);
        }
        
        
    }
}