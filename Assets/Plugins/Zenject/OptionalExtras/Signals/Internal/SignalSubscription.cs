using System;
using ModestTree;

namespace Zenject
{
    public class SignalSubscription : IDisposable, IPoolable<Action<object>, SignalDeclaration>
    {
        readonly Pool _pool;

        Action<object> _callback;
        SignalDeclaration _declaration;
        Type _signalType;

        public SignalSubscription(Pool pool)
        {
            _pool = pool;

            SetDefaults();
        }

        public Type SignalType
        {
            get { return _signalType; }
        }

        public void OnSpawned(
            Action<object> callback, SignalDeclaration declaration)
        {
            Assert.IsNull(_callback);
            _callback = callback;
            _declaration = declaration;
            // Cache this in case OnDeclarationDespawned is called
            _signalType = declaration.SignalType;

            declaration.Add(this);
        }

        public void OnDespawned()
        {
            if (_declaration != null)
            {
                _declaration.Remove(this);
            }

            SetDefaults();
        }

        void SetDefaults()
        {
            _callback = null;
            _declaration = null;
            _signalType = null;
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        // See comment in SignalDeclaration for why this exists
        public void OnDeclarationDespawned()
        {
            _declaration = null;
        }

        public void Invoke(object signal)
        {
            _callback(signal);
        }

        public class Pool : PoolableMemoryPool<Action<object>, SignalDeclaration, SignalSubscription>
        {
        }
    }
}
