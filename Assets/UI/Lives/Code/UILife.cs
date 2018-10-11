using UnityEngine;
using Zenject;

namespace UI.Lives.Code
{
    public class UILife : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<UILife>
        {
        }
    }
}