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
        [DynamicData(nameof(ResolvableFromEmpty_Data), typeof(PatternBase))]
        public virtual void ResolvableFromEmptyRequired(string test, Type type, string name, Type expected)
        {
            // Arrange
            var target = AnnotatedRequired.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, name);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }

        [DataTestMethod]
        [DynamicData(nameof(ResolvableFromEmpty_Data), typeof(PatternBase))]
        public virtual void ResolvableFromEmptyOptional(string test, Type type, string name, Type expected)
        {
            // Arrange
            var target = AnnotatedOptional.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }


        [DataTestMethod]
        [DynamicData(nameof(UnResolvableFromEmpty_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void UnResolvableFromEmptyRequired(string test, Type type)
        {
            // Arrange
            var target = AnnotatedRequired.MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }

        [DataTestMethod]
        [DynamicData(nameof(UnResolvableFromEmpty_Data), typeof(PatternBase))]
        public virtual void UnResolvableFromEmptyOptional(string test, Type type)
        {
            // Arrange
            var target = AnnotatedOptional.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }
    }
}
