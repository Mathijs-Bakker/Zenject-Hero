using UnityEngine;
using Zenject;

namespace Code
{
    public class UIDynamite : MonoBehaviour 
    {
        public class Pool : MonoMemoryPool<UIDynamite>
        {
        }
    }
}
