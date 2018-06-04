using System;
using System.Collections.Generic;
using ModestTree;
using System.Linq;

#if ZEN_SIGNALS_ADD_UNIRX
using UniRx;
#endif

namespace Zenject
{
    public class SignalDeclaration : IDisposable
    {
        public static readonly StaticMemoryPool<Type, bool, bool, SignalSettings, SignalDeclaration> Pool =
            new StaticMemoryPool<Type, bool, bool, SignalSettings, SignalDeclaration>(OnSpawned, OnDespawned);

        readonly List<SignalSubscription> _subscriptions;
        readonly List<ISignal> _signalQueue;

#if ZEN_SIGNALS_ADD_UNIRX
        Subject<object> _stream;
#endif

        Type _signalType;
        bool _requireHandler;
        bool _runAsync;
        SignalSettings _settings;

        static void OnDespawned(SignalDeclaration that)
        {
            that.OnDespawned();
        }

        static void OnSpawned(Type signalType, bool requireHandler, bool runAsync, SignalSettings settings, SignalDeclaration that)
        {
            that.OnSpawned(signalType, requireHandler, runAsync, settings);
        }

        public SignalDeclaration()
        {
            _subscriptions = new List<SignalSubscription>();
            _signalQueue = new List<ISignal>();

            SetDefaults();
        }

#if ZEN_SIGNALS_ADD_UNIRX
        public IObservable<object> Stream
        {
            get { return _stream; }
        }
#endif

        public Type SignalType
        {
            get { return _signalType; }
        }

        public void Dispose()
        {
            Pool.Despawn(this);
        }

        void SetDefaults()
        {
#if ZEN_SIGNALS_ADD_UNIRX
            // We could re-use this but let's just create a new one to be extra safe
            // in case some objects are still subscribed to the old one
            _stream = new Subject<object>();
#endif

            _requireHandler = false;
            _runAsync = false;
            _settings = null;
            _signalType = null;
            _subscriptions.Clear();
            _signalQueue.Clear();
        }

        void OnDespawned()
        {
            if (_settings.AddAssertsForStrictDestructionOrder)
            {
                Assert.That(_subscriptions.IsEmpty(),
                    "Found {0} signals still added to declaration {1}", _subscriptions.Count, _signalType);
            }
            else
            {
                // We can't rely entirely on the destruction order in Unity because of
                // the fact that OnDestroy is completely unpredictable.
                // So if you have a GameObjectContext at the root level in your scene, then it
                // might be destroyed AFTER the SceneContext.  So if you have some signal declarations
                // in the scene context, they might get disposed before some of the subscriptions
                // so in this case you need to disconnect from the subscription so that it doesn't
                // try to remove itself after the declaration has been destroyed, which could be
                // especially problematic if the declaration is re-spawned for a different purpose
                for (int i = 0; i < _subscriptions.Count; i++)
                {
                    _subscriptions[i].OnDeclarationDespawned();
                }
            }

            SetDefaults();
        }

        void OnSpawned(Type signalType, bool requireHandler, bool runAsync, SignalSettings settings)
        {
            Assert.IsNull(_signalType);
            Assert.That(_subscriptions.IsEmpty());

            _signalType = signalType;
            _requireHandler = requireHandler;
            _runAsync = runAsync;
            _settings = settings;
        }

        public void Fire(ISignal signal)
        {
            Assert.That(signal.GetType().DerivesFromOrEqual(_signalType));

            if (_runAsync)
            {
                _signalQueue.Add(signal);
            }
            else
            {
                // Cache the callback list to allow handlers to be added from within callbacks
                using (var block = DisposeBlock.Spawn())
                {
                    var subscriptions = block.AllocateList<SignalSubscription>();
                    subscriptions.AddRange(_subscriptions);
                    FireInternal(subscriptions, signal);
                }
            }
        }

        void FireInternal(List<SignalSubscription> subscriptions, ISignal signal)
        {
            if (subscriptions.IsEmpty()
#if ZEN_SIGNALS_ADD_UNIRX
                && !_stream.HasObservers
#endif
                && _requireHandler)
            {
                throw Assert.CreateException(
                    "Fired signal '{0}' but no subscriptions found!  (and signal is marked with RequireHandler)", signal.GetType());
            }

            for (int i = 0; i < subscriptions.Count; i++)
            {
                var subscription = subscriptions[i];

                // This is a weird check for the very rare case where an Unsubscribe is called
                // from within the same callback (see TestSignalsAdvanced.TestSubscribeUnsubscribeInsideHandler)
                if (_subscriptions.Contains(subscription))
                {
                    subscription.Invoke(signal);
                }
            }

#if ZEN_SIGNALS_ADD_UNIRX
            _stream.OnNext(signal);
#endif
        }

        public void Update()
        {
            if (!_signalQueue.IsEmpty())
            {
                // Cache the callback list to allow handlers to be added from within callbacks
                using (var block = DisposeBlock.Spawn())
                {
                    var subscriptions = block.AllocateList<SignalSubscription>();
                    subscriptions.AddRange(_subscriptions);

                    // Cache the signals so that if the signal is fired again inside the handler that it
                    // is not executed until next frame
                    var signals = block.AllocateList<ISignal>();
                    signals.AddRange(_signalQueue);

                    _signalQueue.Clear();

                    for (int i = 0; i < signals.Count; i++)
                    {
                        FireInternal(subscriptions, signals[i]);
                    }
                }
            }
        }

        public void Add(SignalSubscription subscription)
        {
            Assert.That(!_subscriptions.Contains(subscription));
            _subscriptions.Add(subscription);
        }

        public void Remove(SignalSubscription subscription)
        {
            _subscriptions.RemoveWithConfirm(subscription);
        }
    }
}
