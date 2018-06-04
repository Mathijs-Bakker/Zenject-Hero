using System;

namespace Zenject
{
    public interface IMemoryPool
    {
        int NumTotal { get; }
        int NumActive { get; }
        int NumInactive { get; }

        Type ItemType
        {
            get;
        }

        void ExpandPoolBy(int additionalSize);
        void Shrink(int maxInactive);
        void Clear();
    }

    public interface IDespawnableMemoryPool<TValue> : IMemoryPool
    {
        void Despawn(TValue item);
    }

    public interface IMemoryPool<TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn();
    }

    public interface IMemoryPool<in TParam1, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param);
    }

    public interface IMemoryPool<in TParam1, in TParam2, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param1, TParam2 param2);
    }

    public interface IMemoryPool<in TParam1, in TParam2, in TParam3, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param1, TParam2 param2, TParam3 param3);
    }

    public interface IMemoryPool<in TParam1, in TParam2, in TParam3, in TParam4, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
    }

    public interface IMemoryPool<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
    }

    public interface IMemoryPool<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);
    }

    public interface IMemoryPool<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);
    }

    public interface IMemoryPool<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, TValue> : IDespawnableMemoryPool<TValue>
    {
        TValue Spawn(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);
    }
}
