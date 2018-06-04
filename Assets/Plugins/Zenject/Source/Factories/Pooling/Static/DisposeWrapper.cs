using System;
using System.Collections.Generic;
using ModestTree;
using Zenject;

namespace Zenject
{
    public class DisposeWrapper<TValue> : IDisposable
        where TValue : class, new()
    {
        public static readonly StaticMemoryPool<TValue, IDespawnableMemoryPool<TValue>, DisposeWrapper<TValue>> Pool =
            new StaticMemoryPool<TValue, IDespawnableMemoryPool<TValue>, DisposeWrapper<TValue>>(OnSpawned, OnDespawned);

        IDespawnableMemoryPool<TValue> _wrappedPool;
        TValue _value;

        public TValue Value
        {
            get { return _value; }
        }

        public void Dispose()
        {
            Pool.Despawn(this);
        }

        static void OnSpawned(TValue value, IDespawnableMemoryPool<TValue> wrappedPool, DisposeWrapper<TValue> that)
        {
            Assert.IsNotNull(wrappedPool);
            Assert.IsNotNull(value);

            that._wrappedPool = wrappedPool;
            that._value = value;
        }

        static void OnDespawned(DisposeWrapper<TValue> that)
        {
            that._wrappedPool.Despawn(that._value);

            that._value = null;
            that._wrappedPool = null;
        }
    }
}
