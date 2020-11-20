using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Implicit
{
    /// <summary>
    /// Tests invalid parameter types
    /// </summary>
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(ResolvableFromEmpty_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void ThrowsOnRefParameter(string test, Type type, string name, Type expected)
        {
            // Arrange
            var target = GetType("BaselineTestType_Ref`1").MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, name);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, expected);
        }


        [DataTestMethod]
        [DynamicData(nameof(ResolvableFromEmpty_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void ThrowsOnOutParameter(string test, Type type, string name, Type expected)
        {
            // Arrange
            var target = GetType("BaselineTestType_Out`1").MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, name);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, expected);
        }
    }
}
