using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        public virtual void Required_BuiltIn_Import(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Required", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsInstanceOfType(instance.Value, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void Required_BuiltIn_Named(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Required", "BaselineTestTypeNamed`1"))
                .MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null) as PatternBaseType;
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        public virtual void Optional_BuiltIn_Import(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Optional", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsInstanceOfType(instance.Value, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        public virtual void Optional_BuiltIn_Named(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Optional", "BaselineTestTypeNamed`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsNull(instance.Value);
        }
    }
}
