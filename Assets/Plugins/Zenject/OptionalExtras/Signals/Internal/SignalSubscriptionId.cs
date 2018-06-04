using System;
using ModestTree;

namespace Zenject
{
    [System.Diagnostics.DebuggerStepThrough]
    public struct SignalSubscriptionId : IEquatable<SignalSubscriptionId>
    {
        public SignalSubscriptionId(Type signalType, object callback)
        {
            Assert.That(signalType.DerivesFrom<ISignal>());

            SignalType = signalType;
            Callback = callback;
        }

        public Type SignalType
        {
            get; private set;
        }

        public object Callback
        {
            get; private set;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 29 + SignalType.GetHashCode();
                hash = hash * 29 + Callback.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object that)
        {
            if (that is SignalSubscriptionId)
            {
                return this.Equals((SignalSubscriptionId)that);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(SignalSubscriptionId that)
        {
            return object.Equals(this.SignalType, that.SignalType)
                && object.Equals(this.Callback, that.Callback);
        }

        public static bool operator == (SignalSubscriptionId left, SignalSubscriptionId right)
        {
            return left.Equals(right);
        }

        public static bool operator != (SignalSubscriptionId left, SignalSubscriptionId right)
        {
            return !left.Equals(right);
        }
    }
}
