using System;
using UnityEngine;

namespace Code
{
    public abstract class PlayerState : IDisposable
    {

        public virtual void Start()
        {
            // optionally overridden.
        }

        public abstract void Update();
        
        public virtual void Dispose()
        {
            // optionally overridden.
        }
    }
}