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

        protected virtual void Assert_Injected(Type import, InjectionMember injected, object expected)
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
        }
        
        protected void Assert_Injected(Type importType, InjectionMember member, object expected, object @default)
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
        
        protected void Assert_InjectNamed(Type import, InjectionMember injected, object expected)
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
        }

        protected void Assert_InjectNamed(Type importType, InjectionMember member, object expected, object @default)
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

        #endregion


        #region Generic

        protected void Assert_InjectedGeneric(Type import, InjectionMember injected, object expected)
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
        }

        protected void Assert_InjectedGeneric(Type importType, InjectionMember member, object expected, object @default)
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

        protected void Assert_InjectNamedGeneric(Type import, InjectionMember injected, object expected)
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
        }

        protected void Assert_InjectNamedGeneric(Type importType, InjectionMember member, object expected, object @default)
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


        #region Array

        protected void Assert_InjectArray(Type importType, InjectionMember injection, object[] values)
        {
            // Arrange
            var type = BaselineArrayType.MakeGenericType(importType);

            Container.RegisterType(null, type, null, null, injection);

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            var list = instance.Value as IList;
            Assert.IsNotNull(list);

            for (var i = 0; i < values.Length; i++) 
                Assert.IsTrue(list.Contains(values[i]));
        }
        
        protected void Assert_GenericArray(Type importType, InjectionMember injection, object[] values)
        {
            // Arrange
            var type = BaselineArrayType.MakeGenericType(importType);

            Container.RegisterType(null, BaselineArrayType, null, null, injection);

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            var list = instance.Value as IList;
            Assert.IsNotNull(list);

            for (var i = 0; i < values.Length; i++)
                Assert.IsTrue(list.Contains(values[i]));
        }

        #endregion


        #region Override

        protected virtual void Assert_Override(Type type, ResolverOverride @override, object expected)
        {
            // Arrange
            Container.RegisterType(null, type, null, null);

            // Validate
            var instance = Container.Resolve(type, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected virtual void Assert_Registered(Type type, ResolverOverride @override, object value, object @default)
        {
            // Arrange
            Container.RegisterType(null, type, null, null);

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(type, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(value, instance.Value);
            Assert.AreEqual(@default, instance.Default);
        }

        #endregion


        #region Injected Override

        protected void Assert_Override(Type type, InjectionMember injection, ResolverOverride @override, object expected)
        {
            // Arrange
            Container.RegisterType(null, type, null, null, injection);

            // Validate
            var instance = Container.Resolve(type, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void Assert_Registered(Type type, InjectionMember injection, ResolverOverride @override, object expected)
        {
            // Arrange
            Container.RegisterType(null, type, null, null, injection);

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(type, null, @override) as FixtureBaseType;

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
    }
}


