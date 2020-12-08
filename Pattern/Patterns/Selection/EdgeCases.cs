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
        [DynamicData(nameof(EdgeCases_Data))]
        [PatternTestMethod("Edge Cases ({2})"), TestCategory(SELECTION_EDGE)]
        public virtual void Selection_EdgeCases_Successfull(string test, Type type) 
            => Assert_ResolutionSuccess(type);

        [ExpectedException(typeof(ResolutionFailedException))]
        [DynamicData(nameof(EdgeCases_Throwing_Data))]
        [PatternTestMethod("Edge Cases ({2})"), TestCategory(SELECTION_EDGE)]
        public virtual void Selection_EdgeCases_Throwing(string test, Type type)
            => Assert_ResolutionSuccess(type);
    }
}
