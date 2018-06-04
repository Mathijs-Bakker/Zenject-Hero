using System;
using ModestTree;

namespace Zenject
{
    public class SignalSubscription : IDisposable
    {
        public static readonly StaticMemoryPool<Action<object>, SignalDeclaration, SignalSubscription> Pool =
            new StaticMemoryPool<Action<object>, SignalDeclaration, SignalSubscription>(OnSpawned, OnDespawned);

        Action<object> _callback;
        SignalDeclaration _declaration;
        Type _signalType;

        public SignalSubscription()
        {
            SetDefaults();
        }

        static void OnDespawned(SignalSubscription that)
        {
            if (that._declaration != null)
            {
                that._declaration.Remove(that);
            }

            that.SetDefaults();
        }

        static void OnSpawned(Action<object> callback, SignalDeclaration declaration, SignalSubscription that)
        {
            Assert.IsNull(that._callback);
            that._callback = callback;
            that._declaration = declaration;
            // Cache this in case OnDeclarationDespawned is called
            that._signalType = declaration.SignalType;

            declaration.Add(that);
        }

        public Type SignalType
        {
            get { return _signalType; }
        }

        void SetDefaults()
        {
            _callback = null;
            _declaration = null;
            _signalType = null;
        }

        public void Dispose()
        {
            Pool.Despawn(this);
        }

        // See comment in SignalDeclaration for why this exists
        public void OnDeclarationDespawned()
        {
            _declaration = null;
        }

        public void Invoke(ISignal signal)
        {
            _callback(signal);
        }
    }
}
