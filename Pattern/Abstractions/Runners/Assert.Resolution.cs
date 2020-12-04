using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        public object Assert_ResolutionSuccess(Type type)
        {
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            return instance;
        }


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

        protected void Assert_Override(Type type, InjectionMember member, ResolverOverride @override, object expected)
        {
            // Arrange
            Container.RegisterType(null, type, null, null, member);

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

        protected virtual void Assert_SuccessfulIfRegistered(Type type, ResolverOverride @override, object value, object @default)
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

        protected void Assert_SuccessfulIfRegistered(Type type, InjectionMember injection, ResolverOverride @override, object expected)
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


        #region Failed

        protected virtual void Assert_Fail(Type type, InjectionMember member)
        {
            Container.RegisterType(null, type, null, null, member);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(type, null));

            // Register missing types
            RegisterTypes();

            // Act
            _ = Container.Resolve(type, null);
        }

        #endregion
    }
}
