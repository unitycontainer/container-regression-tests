using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Import
{
    public abstract partial class Pattern
    {

        protected void TestRequiredImport(Type definition, Type importType, InjectionMember injected, object expected)
        {
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, type, null, null, injected);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(type, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void TestRequiredGeneric(Type definition, Type importType, InjectionMember injected, object expected)
        {
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, definition, null, null, injected);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(type, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }
    }
}


