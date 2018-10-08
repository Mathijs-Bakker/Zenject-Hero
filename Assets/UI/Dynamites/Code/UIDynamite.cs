using UnityEngine;
using Zenject;

namespace UI.Dynamites.Code
{
    public class UIDynamite : MonoBehaviour 
    {
        public class Pool : MonoMemoryPool<UIDynamite>
        {
        }
    }
}
