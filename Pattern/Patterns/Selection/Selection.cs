using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection
{
    public abstract partial class Pattern
    {
        [DynamicData(nameof(TestCases_Data))]
        [PatternTestMethod("Test Cases ({2})"), TestCategory(SELECTION_EDGE)]
        public virtual void Selection_TestCases_Successful(string test, Type type)
        {
            var instance = Assert_ResolutionSuccess(type);

            if (instance is not SelectionBaseType selection) return;

            Assert.IsTrue(selection.IsSuccessful);
        }

        [ExpectedException(typeof(ResolutionFailedException))]
        [DynamicData(nameof(TestCases_Throwing_Data))]
        [PatternTestMethod("Test Cases ({2})"), TestCategory(SELECTION_EDGE)]
        public virtual void Selection_TestCases_Throwing(string test, Type type)
            => Assert_ResolutionSuccess(type);

        [ExpectedException(typeof(ResolutionFailedException))]
        [DynamicData(nameof(Validation_Data))]
        [PatternTestMethod("Validation ({2})"), TestCategory(SELECTION_EDGE)]
        public virtual void Selection_Validation_Throwing(string test, Type type)
            => Assert_ResolutionSuccess(type);
    }
}
