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
        #region Required

        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Required_FromEmpty_Valid(string test, Type type)
        {
            // Arrange
            var target = (TypeDefinition ??= GetType("Required", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }


        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Required_FromEmpty_Valid_Named(string test, Type type)
        {
            // Arrange
            var target = (TypeDefinition ??= GetType("Required", "BaselineTestTypeNamed`1"))
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
        public virtual void Required_FromEmpty_Invalid(string test, Type type)
        {
            // Arrange
            var target = (TypeDefinition ??= GetType("Required", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Optional_FromEmpty_Valid(string test, Type type)
        {
            // Arrange
            var target = (TypeDefinition ??= GetType("Optional", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }


        [DataTestMethod]
        [DynamicData(nameof(UnResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Optional_FromEmpty_Invalid(string test, Type type)
        {
            // Arrange
            var target = (TypeDefinition ??= GetType("Optional", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }

        #endregion
    }
}
