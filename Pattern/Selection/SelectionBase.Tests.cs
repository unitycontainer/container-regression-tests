using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection
{
    public abstract partial class SelectionBase
    {

        [DataTestMethod, DynamicData(nameof(EdgeCases_Data))]
        public virtual void Selection_EdgeCases_Successfull(string test, Type type)
        {
            // Arrange
            RegisterTypes();

            // Act
            var instance = AssertResolutionPattern(type);

            // Validate
            Assert.IsTrue(instance.IsSuccessfull);
        }

        [ExpectedException(typeof(ResolutionFailedException))]
        [DataTestMethod, DynamicData(nameof(EdgeCases_Throwing_Data))]
        public virtual void Selection_EdgeCases_Throwing(string test, Type type)
        {
            // Arrange
            RegisterTypes();

            // Act
            _ = AssertResolutionPattern(type);
        }
    }
}
