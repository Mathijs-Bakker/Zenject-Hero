using UnityEngine;

namespace CaveIn.Contracts
{
    public abstract class Explodable : MonoBehaviour
    {
        public abstract void ReceiveDamage(int damage);
        public abstract void BlowUp();
    }
}