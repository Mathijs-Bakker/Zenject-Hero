using UnityEngine;

namespace Code
{
    public class CaveIn : MonoBehaviour, IDamageable
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

        public void BlowUp()
        {
            Destroy(gameObject);
        }
    }
}