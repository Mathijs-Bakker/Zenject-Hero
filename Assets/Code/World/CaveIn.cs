using UnityEngine;

namespace Code
{
    public class CaveIn : Damageable
    {
        [SerializeField] private int _health;
        
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
        }
    }
}