using System;
using Zenject;

namespace Code
{
    public abstract class GameStateEntity : IInitializable, ITickable, IDisposable
    {
        public virtual void Dispose()
        {
            // Optionally overridden.
        }

        public virtual void Initialize()
        {
            // Optionally overridden.
        }

        public virtual void Tick()
        {
            // Optionally overridden.
        }

        public virtual void Start()
        {
            // Optionally overridden.
        }
    }
}