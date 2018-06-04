using System;
using ModestTree;

namespace Zenject
{
#if NET_4_6
    public interface ILazyProvider
    {
        object GetLazy();
    }

    public class LazyWrapper<T> : IValidatable, ILazyProvider
    {
        readonly DiContainer _container;
        readonly InjectContext _context;

        Lazy<T> _lazy;

        public LazyWrapper(DiContainer container, InjectContext context)
        {
            Assert.DerivesFromOrEqual<T>(context.MemberType);

            _container = container;
            _context = context;
            _lazy = new Lazy<T>(GetValue);
        }

        public object GetLazy()
        {
            return _lazy;
        }

        void IValidatable.Validate()
        {
            // Cannot cast
            _container.Resolve(_context);
        }

        public T GetValue()
        {
            return (T)_container.Resolve(_context);
        }
    }
#else
    [ZenjectAllowDuringValidationAttribute]
    public class Lazy<T> : IValidatable
    {
        readonly DiContainer _container;
        readonly InjectContext _context;

        bool _hasValue;
        T _value;

        public Lazy(DiContainer container, InjectContext context)
        {
            Assert.DerivesFromOrEqual<T>(context.MemberType);

            _container = container;
            _context = context;
        }

        void IValidatable.Validate()
        {
            _container.Resolve(_context);
        }

        public T Value
        {
            get
            {
                if (!_hasValue)
                {
                    _value = (T)_container.Resolve(_context);
                    _hasValue = true;
                }

                return _value;
            }
        }
    }
#endif
}
