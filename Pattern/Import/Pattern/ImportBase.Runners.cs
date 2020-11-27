using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
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


        #region Built-In Types

        protected void TestArrayImport(Type definition, Type importType)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(0, (instance.Value as IList)?.Count ?? -1);

            RegisterArrayTypes();

            // Act
            instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
#if BEHAVIOR_V4
            Assert.AreEqual(3, (instance.Value as IList)?.Count ?? -1);
#else
            Assert.AreEqual(4, (instance.Value as IList)?.Count ?? -1);
#endif
        }


        protected void TestArrayImport(Type definition, Type importType, InjectionMember injection)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, type, null, null, injection);

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(6, (instance.Value as IList)?.Count ?? -1);
        }

        protected IList TestGenericArrayImport(Type definition, Type importType, InjectionMember injection)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, definition, null, null, injection);

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            
            var list = instance.Value as IList;
            Assert.IsNotNull(list);
            Assert.AreEqual(6, list?.Count ?? -1);

            return list;
        }

        protected void TestEnumerableImport(Type definition, Type importType)
        {
            // Arrange
            var type = definition.MakeGenericType(typeof(IEnumerable<>).MakeGenericType(importType));

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(0, (instance.Value as IEnumerable)?.Cast<object>().Count() ?? -1);

            RegisterArrayTypes();

            // Act
            instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(5, (instance.Value as IEnumerable)?.Cast<object>().Count() ?? -1);
        }

        protected void TestLazyImport(Type definition, Type importType, object expected)
        {
            // Arrange
            var type = definition.MakeGenericType(typeof(Lazy<>).MakeGenericType(importType));

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Value);
            Assert.IsInstanceOfType(instance, type);

            Assert.ThrowsException<ResolutionFailedException>(() =>
            {
                switch (instance.Value)
                {
                    case Lazy<int> integer:
                        _ = integer.Value;
                        break;

                    case Lazy<string> letters:
                        _ = letters.Value;
                        break;

                    case Lazy<Unresolvable> unresolvable:
                        _ = unresolvable.Value;
                        break;

                    default:
                        Assert.Fail("Unknown");
                        break;
                }
            });

            RegisterTypes();

            instance = Container.Resolve(type, null) as PatternBaseType;

            // Act
            var value = instance.Value switch
            {
                Lazy<int> integer               => (object)integer.Value,
                Lazy<string> letters            => (object)letters.Value,
                Lazy<Unresolvable> unresolvable => (object)unresolvable.Value,
                _ => throw new NotImplementedException(),
            };

            // Validate
            Assert.AreEqual(expected, value);
        }


        protected void TestFuncImport(Type definition, Type importType, object expected)
        {
            // Arrange
            var type = definition.MakeGenericType(typeof(Func<>).MakeGenericType(importType));

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Value);
            Assert.IsInstanceOfType(instance, type);

            Assert.ThrowsException<ResolutionFailedException>(() =>
            {
                switch (instance.Value)
                {
                    case Func<int> integer:
                        _ = integer();
                        break;

                    case Func<string> letters:
                        _ = letters();
                        break;

                    case Func<Unresolvable> unresolvable:
                        _ = unresolvable();
                        break;

                    default:
                        Assert.Fail("Unknown");
                        break;
                }
            });

            RegisterTypes();

            // Act
            var value = instance.Value switch
            {
                Func<int> integer => (object)integer(),
                Func<string> letters => (object)letters(),
                Func<Unresolvable> unresolvable => (object)unresolvable(),
                _ => throw new NotImplementedException(),
            };

            // Validate
            Assert.AreEqual(expected, value);
        }

        #endregion


        #region Implementation

        public static object GetDefaultValue(Type t)
            => (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
                ? Activator.CreateInstance(t) : null;

        #endregion
    }
}


