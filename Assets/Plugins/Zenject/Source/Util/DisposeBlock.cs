using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject
{
    public static class DisposeBlockExtensions
    {
        public static T AttachedTo<T>(this T disposable, DisposeBlock block)
            where T : IDisposable
        {
            block.Add(disposable);
            return disposable;
        }
    }

    public class DisposeBlock : IDisposable
    {
        static readonly StaticMemoryPool<DisposeBlock> _pool =
            new StaticMemoryPool<DisposeBlock>(OnSpawned, OnDespawned);

        readonly List<IDisposable> _disposables = new List<IDisposable>();

        static void OnSpawned(DisposeBlock that)
        {
            Assert.That(that._disposables.Count == 0);
        }

        static void OnDespawned(DisposeBlock that)
        {
            // Dispose in reverse order since usually that makes the most sense
            for (int i = that._disposables.Count - 1; i >= 0; i--)
            {
                that._disposables[i].Dispose();
            }
            that._disposables.Clear();
        }

        public void AddRange<T>(IList<T> disposables)
            where T : IDisposable
        {
            for (int i = 0; i < disposables.Count; i++)
            {
                _disposables.Add(disposables[i]);
            }
        }

        public List<T> AllocateList<T>(IEnumerable<T> elements)
        {
            return ListPool<T>.Instance
                .SpawnWrapper(elements).AttachedTo(this).Value;
        }

        public List<T> AllocateList<T>()
        {
            return ListPool<T>.Instance
                .SpawnWrapper().AttachedTo(this).Value;
        }

        public void Add(IDisposable disposable)
        {
            Assert.That(!_disposables.Contains(disposable));
            _disposables.Add(disposable);
        }

        public void Remove(IDisposable disposable)
        {
            _disposables.RemoveWithConfirm(disposable);
        }

        public static DisposeBlock Spawn()
        {
            return _pool.Spawn();
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
    }
}
