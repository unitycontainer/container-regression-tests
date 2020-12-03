using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
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
    }
}
