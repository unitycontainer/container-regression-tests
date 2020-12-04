using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        protected FixtureBaseType Asssert_AlwaysSuccessful(Type type, object @default, object registered)
        {
            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);
            
            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);

            return instance;
        }

        protected FixtureBaseType Asssert_AlwaysSuccessful(Type type, InjectionMember member, object @default, object registered)
        {
            // Inject
            Container.RegisterType(null, type, null, null, member);

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);

            return instance;
        }

        protected FixtureBaseType Asssert_AlwaysSuccessful(Type definition, Type type, InjectionMember member, object @default, object registered)
        {
            var target = definition.MakeGenericType(type);

            // Inject
            Container.RegisterType(null, definition, null, null, member);

            // Act
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
            Assert.AreEqual(registered, instance.Value);

            return instance;
        }
    }
}
