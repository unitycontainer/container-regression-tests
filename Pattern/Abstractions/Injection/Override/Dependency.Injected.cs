using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Injection
{
    public abstract partial class Pattern 
    {
        #region Type


        [PatternTestMethod("Override injection unmatchig Type")]
        [TestProperty(OVERRIDE, nameof(DependencyOverride))]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Dependency_Injected_ByType_NoMatch(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                              InjectionMember_Value(new InjectionParameter(injected)),
                              new DependencyOverride(typeof(Pattern), overridden),
                              injected);
        #endregion
    }
}
