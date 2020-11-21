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
        private Type _typeDefinition;

        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void TypeFromEmpty_Required(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Required", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }

        [DataTestMethod]
        [DynamicData(nameof(UnResolvableTypes_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void InvalidTypeFromEmpty_Required(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Required", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }


        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void TypeFromEmpty_Optional(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Optional", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }

        [DataTestMethod]
        [DynamicData(nameof(UnResolvableTypes_Data), typeof(PatternBase))]
        public virtual void InvalidTypeFromEmpty_Optional(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Optional", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }
    }
}
