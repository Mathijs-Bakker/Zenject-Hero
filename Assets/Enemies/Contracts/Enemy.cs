using UnityEngine;

namespace Enemies.Contracts
{
    public abstract class Enemy : MonoBehaviour
    {
        public abstract void ReceiveDamage(int damage);
        public abstract void Die();
    }
}