using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Resolution
{
    public partial class FromEmpty
    {
        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        public virtual void BuiltIn_Interface(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreSame(Container, instance);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        public virtual void BuiltIn_InChild(string test, Type type)
        {
            // Arrange
            var child = Container.CreateChildContainer();

            // Act
            var instance = child.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreSame(child, instance);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void BuiltIn_Named(string test, Type type)
        {
            // Act
            _ = Container.Resolve(type, Name);
        }
    }
}
