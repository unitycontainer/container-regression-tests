using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import
{
    public abstract partial class ImportBase
    {
        #region Injected

        private static IDictionary<Type, object> _injected = new Dictionary<Type, object>
        {
            { typeof(int),          InjectedInt },
            { typeof(string),       InjectedString },
            { typeof(Unresolvable), InjectedUnresolvable },
        };

        protected virtual object GetInjectedValue(Type type)
            => _injected[type];

        #endregion


        #region Overrides

        private static IDictionary<Type, object> _overrides = new Dictionary<Type, object>
        {
            { typeof(int),          OverriddenInt },
            { typeof(string),       OverriddenString },
            { typeof(Unresolvable), OverriddenUnresolvable },
        };

        protected virtual object GetOverrideValue(Type type)
            => _overrides[type];


        #endregion


        public interface IFoo<TEntity>
        {
            TEntity Value { get; }
        }

        public class Foo<TEntity> : IFoo<TEntity>
        {
            public Foo() { }
            public TEntity Value { get; protected set; }
        }


        public class OtherFoo<TEntity> : Foo<TEntity>
        {
            public OtherFoo(TEntity value) => Value = value;
        }
    }
}


