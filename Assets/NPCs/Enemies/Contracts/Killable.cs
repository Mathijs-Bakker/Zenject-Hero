using UnityEngine;

namespace Enemies.Contracts
{
    public abstract class Killable : MonoBehaviour
    {
        public abstract void ReceiveDamage(int damage);
        public abstract void Die();
    }
}