using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Import.Annotated
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Required_Registered_Invalid(string test, Type type)
        {
            // Arrange
            RegisterUnResolvableTypes();
            var target = RequiredImportType.MakeGenericType(type);


            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(Container.Resolve(type, null), instance.Value);
        }

        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Optional_Registered_Invalid(string test, Type type)
        {
            // Arrange
            RegisterUnResolvableTypes();
            var target = OptionalImportType.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(Container.Resolve(type, null), instance.Value);
        }
    }
}
