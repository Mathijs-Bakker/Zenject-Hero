using UnityEngine;
using Zenject;

namespace Code
{
    public class UILife : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<UILife>
        {
        }
    }
}