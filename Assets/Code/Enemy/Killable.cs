using UnityEngine;

namespace Code
{
    public abstract class Killable : MonoBehaviour
    {
        public abstract void ReceiveDamage(int damage);

        public abstract void Die();
    }
}