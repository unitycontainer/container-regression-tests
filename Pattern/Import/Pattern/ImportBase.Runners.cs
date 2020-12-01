using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections;
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
        #region Injected

        protected virtual FixtureBaseType Assert_Injected(Type import, InjectionMember injected, object expected)
        {
            var target = BaselineTestType.MakeGenericType(import);

            Container.RegisterType(null, target, null, null, injected);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            return instance;
        }

        protected FixtureBaseType Assert_InjectNamed(Type import, InjectionMember injected, object expected)
        {
            var target = BaselineTestNamed.MakeGenericType(import);

            Container.RegisterType(null, target, null, null, injected);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            return instance;
        }

        protected FixtureBaseType Assert_InjectArray(Type importType, InjectionMember injection, object[] values)
        {
            // Arrange
            var type = BaselineTestType.MakeGenericType(importType.MakeArrayType());

            Container.RegisterType(null, type, null, null, injection);

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            var list = instance.Value as IList;
            Assert.IsNotNull(list);

            for (var i = 0; i < values.Length; i++) 
                Assert.AreEqual(values[i], list[i]);

            return instance;
        }

        protected FixtureBaseType Assert_InjectGeneric(Type import, InjectionMember injected, object expected)
        {
            var target = BaselineTestType.MakeGenericType(import);

            Container.RegisterType(null, BaselineTestType, null, null, injected);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            return instance;
        }

        protected FixtureBaseType Assert_InjectNamedGeneric(Type import, InjectionMember injected, object expected)
        {
            var target = BaselineTestNamed.MakeGenericType(import);

            Container.RegisterType(null, BaselineTestNamed, null, null, injected);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            return instance;
        }

        #endregion


        #region With Defaults

        protected void Assert_InjectedOrDefault(Type importType, InjectionMember member, object expected, object @default)
        {
            // Arrange
            var target = BaselineTestType.MakeGenericType(importType);

            Container.RegisterType(null, target, null, null, member);

            // Validate
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void Assert_InjectNamedOrDefault(Type importType, InjectionMember member, object expected, object @default)
        {
            // Arrange
            var target = BaselineTestNamed.MakeGenericType(importType);

            Container.RegisterType(null, target, null, null, member);

            // Validate
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void Assert_InjectedGenericOrDefault(Type importType, InjectionMember member, object expected, object @default)
        {
            // Arrange
            var target = BaselineTestType.MakeGenericType(importType);

            Container.RegisterType(null, BaselineTestType, null, null, member);

            // Validate
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void Assert_InjectNamedGenericOrDefault(Type importType, InjectionMember member, object expected, object @default)
        {
            // Arrange
            var target = BaselineTestNamed.MakeGenericType(importType);

            Container.RegisterType(null, BaselineTestNamed, null, null, member);

            // Validate
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as FixtureBaseType;

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
            var instance = Container.Resolve(type, null, @override) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, @override) as ImportBaseType;

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
            var instance = Container.Resolve(type, null, target) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, target) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        #endregion


        #region Built-In Types

        protected IList TestGenericArrayImport(Type definition, Type importType, InjectionMember injection)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, definition, null, null, injection);

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            
            var list = instance.Value as IList;
            Assert.IsNotNull(list);
            Assert.AreEqual(6, list?.Count ?? -1);

            return list;
        }

        #endregion


        #region Implementation

        public static object GetDefaultValue(Type t)
            => (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
                ? Activator.CreateInstance(t) : null;

        #endregion
    }
}


