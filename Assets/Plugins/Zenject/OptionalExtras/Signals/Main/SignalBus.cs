using System;
using System.Collections.Generic;
using ModestTree;
using System.Linq;

#if ZEN_SIGNALS_ADD_UNIRX
using UniRx;
#endif

namespace Zenject
{
    public class SignalBus : ILateDisposable, ITickable
    {
        readonly Dictionary<Type, SignalDeclaration> _localDeclarationMap;
        readonly List<SignalDeclaration> _localDeclarations;
        readonly SignalBus _parentBus;
        readonly Dictionary<SignalSubscriptionId, SignalSubscription> _subscriptionMap = new Dictionary<SignalSubscriptionId, SignalSubscription>();
        readonly SignalSettings _settings;

        public SignalBus(
            [Inject(Source = InjectSources.Local)]
            List<SignalDeclarationBindInfo> signalBindings,
            [Inject(Source = InjectSources.Parent, Optional = true)]
            SignalBus parentBus,
            [Inject(Optional = true)]
            SignalSettings settings)
        {
            _settings = settings ?? SignalSettings.Default;
            _localDeclarations = new List<SignalDeclaration>();
            _localDeclarationMap = new Dictionary<Type, SignalDeclaration>();
            _parentBus = parentBus;

            for (int i = 0; i < signalBindings.Count; i++)
            {
                var signalBindInfo = signalBindings[i];
                Assert.That(signalBindInfo.SignalType.DerivesFrom<ISignal>());

                var declaration = SignalDeclaration.Pool.Spawn(
                    signalBindInfo.SignalType, signalBindInfo.RequireHandler, signalBindInfo.RunAsync, _settings);

                _localDeclarations.Add(declaration);
                _localDeclarationMap.Add(signalBindInfo.SignalType, declaration);
            }
        }

        public int NumSubscribers
        {
            get { return _subscriptionMap.Count; }
        }

        public void LateDispose()
        {
            if (_settings.AutoUnsubscribeInDispose)
            {
                foreach (var subscription in _subscriptionMap.Values)
                {
                    subscription.Dispose();
                }
            }
            else
            {
                if (!_subscriptionMap.IsEmpty())
                {
                    throw Assert.CreateException(
                        "Found subscriptions for signals '{0}' in SignalBus.LateDispose!  Either add the explicit Unsubscribe or set SignalSettings.AutoUnsubscribeInDispose to true",
                        _subscriptionMap.Values.Select(x => x.SignalType.PrettyName()).Join(", "));
                }
            }

            for (int i = 0; i < _localDeclarations.Count; i++)
            {
                _localDeclarations[i].Dispose();
            }
        }

        public void Tick()
        {
            for (int i = 0; i < _localDeclarations.Count; i++)
            {
                _localDeclarations[i].Update();
            }
        }

        public void Fire<TSignal>()
            where TSignal : ISignal
        {
            Fire((TSignal)Activator.CreateInstance(typeof(TSignal)));
        }

        public void Fire(ISignal signal)
        {
            GetDeclaration(signal.GetType()).Fire(signal);
        }

#if ZEN_SIGNALS_ADD_UNIRX
        public IObservable<TSignal> GetStream<TSignal>()
        {
            return GetStream(typeof(TSignal)).Select(x => (TSignal)x);
        }

        public IObservable<object> GetStream(Type signalType)
        {
            return GetDeclaration(signalType).Stream;
        }
#endif

        public void Subscribe<TSignal>(Action callback)
            where TSignal : ISignal
        {
            Action<object> wrapperCallback = (args) => callback();
            SubscribeInternal(typeof(TSignal), callback, wrapperCallback);
        }

        public void Subscribe<TSignal>(Action<TSignal> callback)
            where TSignal : ISignal
        {
            Action<object> wrapperCallback = (args) => callback((TSignal)args);
            SubscribeInternal(typeof(TSignal), callback, wrapperCallback);
        }

        public void Subscribe(Type signalType, Action<object> callback)
        {
            SubscribeInternal(signalType, callback, callback);
        }

        public void Unsubscribe<TSignal>(Action callback)
            where TSignal : ISignal
        {
            Unsubscribe(typeof(TSignal), callback);
        }

        public void Unsubscribe(Type signalType, Action callback)
        {
            UnsubscribeInternal(signalType, callback, true);
        }

        public void Unsubscribe(Type signalType, Action<object> callback)
        {
            UnsubscribeInternal(signalType, callback, true);
        }

        public void Unsubscribe<TSignal>(Action<TSignal> callback)
            where TSignal : ISignal
        {
            UnsubscribeInternal(typeof(TSignal), callback, true);
        }

        public void TryUnsubscribe<TSignal>(Action callback)
            where TSignal : ISignal
        {
            UnsubscribeInternal(typeof(TSignal), callback, false);
        }

        public void TryUnsubscribe(Type signalType, Action callback)
        {
            UnsubscribeInternal(signalType, callback, false);
        }

        public void TryUnsubscribe(Type signalType, Action<object> callback)
        {
            UnsubscribeInternal(signalType, callback, false);
        }

        public void TryUnsubscribe<TSignal>(Action<TSignal> callback)
            where TSignal : ISignal
        {
            UnsubscribeInternal(typeof(TSignal), callback, false);
        }

        void UnsubscribeInternal(Type signalType, object token, bool throwIfMissing)
        {
            UnsubscribeInternal(
                new SignalSubscriptionId(signalType, token), throwIfMissing);
        }

        void UnsubscribeInternal(SignalSubscriptionId id, bool throwIfMissing)
        {
            SignalSubscription subscription;

            if (_subscriptionMap.TryGetValue(id, out subscription))
            {
                _subscriptionMap.RemoveWithConfirm(id);
                subscription.Dispose();
            }
            else
            {
                if (throwIfMissing)
                {
                    throw Assert.CreateException(
                        "Called unsubscribe for signal '{0}' but could not find corresponding subscribe.  If this is intentional, call TryUnsubscribe instead.");
                }
            }
        }

        void SubscribeInternal(Type signalType, object token, Action<object> callback)
        {
            SubscribeInternal(
                new SignalSubscriptionId(signalType, token), callback);
        }

        void SubscribeInternal(SignalSubscriptionId id, Action<object> callback)
        {
            Assert.That(!_subscriptionMap.ContainsKey(id),
                "Tried subscribing to the same signal with the same callback on Zenject.SignalBus");

            var declaration = GetDeclaration(id.SignalType);
            var subscription = SignalSubscription.Pool.Spawn(callback, declaration);

            _subscriptionMap.Add(id, subscription);
        }

        SignalDeclaration GetDeclaration(Type signalType)
        {
            SignalDeclaration handler;

            if (_localDeclarationMap.TryGetValue(signalType, out handler))
            {
                return handler;
            }

            if (_parentBus != null)
            {
                return _parentBus.GetDeclaration(signalType);
            }

            throw Assert.CreateException(
                "Fired undeclared signal with type '{0}'!", signalType);
        }
    }
}
