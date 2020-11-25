using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class ImportBase
    {
        #region With Defaults

        protected void TestWithDefault(Type definition, Type importType, object expected, object @default)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            // Validate
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void TestWithDefault(Type definition, Type importType, InjectionMember injected, object expected, object @default)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, type, null, null, injected);

            // Validate
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        #endregion

        
        #region With Overrides

        protected void TestWithOverride(Type definition, Type importType, ResolverOverride @override, object expected, object @default)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, type, null, null);

            // Validate
            var instance = Container.Resolve(type, null, @override) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, @override) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }


        protected void TestWithOverrideOnType(Type definition, Type importType, ResolverOverride @override, object expected, object @default)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);
            var target = @override.OnType(type);

            Container.RegisterType(null, type, null, null);

            // Validate
            var instance = Container.Resolve(type, null, target) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, target) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        #endregion


        #region Implementation

        public static object GetDefaultValue(Type t)
            => (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
                ? Activator.CreateInstance(t) : null;

        #endregion


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
    }
}


