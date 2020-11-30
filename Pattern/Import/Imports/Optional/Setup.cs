using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Import.Optional
{
    public abstract partial class Pattern : Common.Pattern
    {
        protected override void AssertImportResolved(Type definition, Type importType, object expected)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

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
        }
    }
}
