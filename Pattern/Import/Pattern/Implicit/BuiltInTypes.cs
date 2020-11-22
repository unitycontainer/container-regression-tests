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
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        public virtual void BuiltIn_Interface(string test, Type type)
        {
            // Arrange
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void BuiltIn_Interface_Named(string test, Type type)
        {
            // Arrange
            // Act
            var instance = Container.Resolve(type, Name);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
        }
    }
}
