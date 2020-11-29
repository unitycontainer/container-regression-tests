using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Implicit
{
    /// <summary>
    /// Tests invalid parameter types
    /// </summary>
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void ThrowsOnRefParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Ref`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }


        [DataTestMethod]
        [DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void ThrowsOnOutParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Out`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }
    }
}
