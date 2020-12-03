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
    public abstract partial class Pattern
    {
        [TestCategory(Category_Import)]
        [ExpectedException(typeof(ResolutionFailedException))]
        [DataTestMethod, DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        public virtual void Throws_OnRefParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Ref`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }

        [TestCategory(Category_Import)]
        [ExpectedException(typeof(ResolutionFailedException))]
        [DataTestMethod, DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        public virtual void Throws_OnOutParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Out`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }
    }
}
