using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Implicit
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void FromEmpty_Resolvable_Type(string test, Type type)
        {
            // Arrange
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void FromEmpty_Resolvable_Named(string test, Type type)
        {
            // Arrange
            // Act
            var instance = Container.Resolve(type, Name);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void FromEmpty_Resolvable_Import(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }

        /// <summary>
        /// Tests exception throwing on unsatisfactory resolution.
        /// </summary>
        [DataTestMethod]
        [DynamicData(nameof(UnResolvableTypes_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void FromEmpty_UnResolvable_Type(string test, Type type)
        {
            // Act
            _ = Container.Resolve(type, null);
        }


        /// <summary>
        /// Tests exception throwing on unsatisfactory resolution.
        /// </summary>
        [DataTestMethod]
        [DynamicData(nameof(UnResolvableTypes_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void FromEmpty_UnResolvable_Import(string test, Type type)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null) as PatternBaseType;
        }
    }
}
