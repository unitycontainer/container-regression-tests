using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using Unity.Injection;

namespace Import.Optional
{
    public abstract partial class Pattern
    {
        protected override FixtureBaseType Assert_Injected(Type importType, InjectionMember injected, object expected)
        {
            // Arrange
            var type = BaselineTestType.MakeGenericType(importType);

            Container.RegisterType(null, type, null, null, injected);

            // Validate
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            return instance;
        }
    }
}
