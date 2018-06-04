using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject
{
    public class PoolExceededFixedSizeException : Exception
    {
        public PoolExceededFixedSizeException(string errorMessage)
            : base(errorMessage)
        {
        }
    }

    [Serializable]
    public class MemoryPoolSettings
    {
        public int InitialSize;
        public PoolExpandMethods ExpandMethod;

        public MemoryPoolSettings(int initialSize, PoolExpandMethods expandMethod)
        {
            InitialSize = initialSize;
            ExpandMethod = expandMethod;
        }

        public static readonly MemoryPoolSettings Default =
            new MemoryPoolSettings(0, PoolExpandMethods.OneAtATime);
    }

    [ZenjectAllowDuringValidation]
    public class MemoryPoolBase<TContract> : IValidatable, IMemoryPool, IDisposable
    {
        Stack<TContract> _inactiveItems;
        IFactory<TContract> _factory;
        MemoryPoolSettings _settings;

        int _activeCount;

        [Inject]
        void Construct(
            IFactory<TContract> factory,
            DiContainer container,
            [InjectOptional]
            MemoryPoolSettings settings)
        {
            _settings = settings ?? MemoryPoolSettings.Default;
            _factory = factory;

            _inactiveItems = new Stack<TContract>(_settings.InitialSize);

            if (!container.IsValidating)
            {
                for (int i = 0; i < _settings.InitialSize; i++)
                {
                    _inactiveItems.Push(AllocNew());
                }
            }

            StaticMemoryPoolRegistry.Add(this);
        }

        public IEnumerable<TContract> InactiveItems
        {
            get { return _inactiveItems; }
        }

        public int NumTotal
        {
            get { return NumInactive + NumActive; }
        }

        public int NumInactive
        {
            get { return _inactiveItems.Count; }
        }

        public int NumActive
        {
            get { return _activeCount; }
        }

        public Type ItemType
        {
            get { return typeof(TContract); }
        }

        public void Dispose()
        {
            StaticMemoryPoolRegistry.Remove(this);
        }

        public void Despawn(TContract item)
        {
            Assert.That(!_inactiveItems.Contains(item),
                "Tried to return an item to pool {0} twice", this.GetType());

            _activeCount--;

            _inactiveItems.Push(item);

#if UNITY_EDITOR && ZEN_PROFILING_ENABLED
            using (ProfileBlock.Start("{0}.OnDespawned", this.GetType()))
#endif
            {
                OnDespawned(item);
            }
        }

        TContract AllocNew()
        {
            try
            {
                var item = _factory.Create();

                // For debugging when new objects should not be re-created
                //ModestTree.Log.Info("Created new object of type '{0}' in pool '{1}'.  Total instances: {2}", typeof(TContract), this.GetType(), this.NumTotal);

                Assert.IsNotNull(item, "Factory '{0}' returned null value when creating via {1}!", _factory.GetType(), this.GetType());
                OnCreated(item);
                return item;
            }
            catch (Exception e)
            {
                throw new ZenjectException(
                    "Error during construction of type '{0}' via {1}.Create method!".Fmt(
                        typeof(TContract), this.GetType().PrettyName()), e);
            }
        }

        void IValidatable.Validate()
        {
            try
            {
                _factory.Create();
            }
            catch (Exception e)
            {
                throw new ZenjectException(
                    "Validation for factory '{0}' failed".Fmt(this.GetType()), e);
            }
        }

        public void Clear()
        {
            Shrink(0);
        }

        /// <summary>
        /// Shrinks the MemoryPool down to a maximum of maxInactive inactive items
        /// </summary>
        /// <param name="maxInactive">The maximum amount of inactive items to keep</param>
        public void Shrink(int maxInactive)
        {
            while (_inactiveItems.Count > maxInactive)
            {
                OnDestroyed(_inactiveItems.Pop());
            }
        }

        protected TContract GetInternal()
        {
            if (_inactiveItems.Count == 0)
            {
                ExpandPool();
                Assert.That(!_inactiveItems.IsEmpty());
            }

            var item = _inactiveItems.Pop();
            _activeCount++;
            OnSpawned(item);
            return item;
        }

        /// <summary>
        /// Expands the pool by the additional size.
        ///
        /// This bypasses the configured expansion method (OneAtATime or Doubling), but still enforces the Fixed size
        /// constraint.
        /// </summary>
        /// <param name="additionalSize">The additional number of items to allocate in the pool.</param>
        /// <exception cref="PoolExceededFixedSizeException">if the pool is configured with a fixed size.</exception>
        public void ExpandPoolBy(int additionalSize)
        {
            if (_settings.ExpandMethod == PoolExpandMethods.Fixed)
            {
                throw new PoolExceededFixedSizeException(
                    "Pool factory '{0}' exceeded its max size of '{1}'!"
                    .Fmt(this.GetType(), NumTotal));
            }

            for (int i = 0; i < additionalSize; i++)
            {
                _inactiveItems.Push(AllocNew());
            }
        }

        void ExpandPool()
        {
            switch (_settings.ExpandMethod)
            {
                case PoolExpandMethods.Fixed:
                {
                    throw new PoolExceededFixedSizeException(
                        "Pool factory '{0}' exceeded its max size of '{1}'!"
                        .Fmt(this.GetType(), NumTotal));
                }
                case PoolExpandMethods.OneAtATime:
                {
                    _inactiveItems.Push(AllocNew());
                    break;
                }
                case PoolExpandMethods.Double:
                {
                    if (NumTotal == 0)
                    {
                        _inactiveItems.Push(AllocNew());
                    }
                    else
                    {
                        var oldSize = NumTotal;

                        for (int i = 0; i < oldSize; i++)
                        {
                            _inactiveItems.Push(AllocNew());
                        }
                    }
                    break;
                }
                default:
                {
                    throw Assert.CreateException();
                }
            }
        }

        protected virtual void OnDespawned(TContract item)
        {
            // Optional
        }

        protected virtual void OnSpawned(TContract item)
        {
            // Optional
        }

        protected virtual void OnCreated(TContract item)
        {
            // Optional
        }

        protected virtual void OnDestroyed(TContract item)
        {
            // Optional
        }
    }
}
