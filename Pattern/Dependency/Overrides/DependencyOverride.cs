using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Dependency
{
    public abstract partial class Pattern
    {
        #region Type

        [TestProperty(OVERRIDE, nameof(DependencyOverride))]
        [DataTestMethod, DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public void Dependency_ByType(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                new DependencyOverride(type, overridden),
                overridden);


#if BEHAVIOR_V5
        [Ignore("https://github.com/unitycontainer/container/issues/140")]
#endif
        [TestProperty(OVERRIDE, nameof(DependencyOverride))]
        [DataTestMethod, DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public void Dependency_ByType_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_AlwaysSuccessful(BaselineTestNamed.MakeGenericType(type),
                new DependencyOverride(type, overridden), overridden);


        [TestProperty(OVERRIDE, nameof(DependencyOverride))]
        [DataTestMethod, DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public void Dependency_ByType_NoMatch(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_FixtureBaseType(BaselineTestType.MakeGenericType(type),
                           new DependencyOverride(typeof(Pattern), overridden),
                           registered, @default);


#if BEHAVIOR_V5
        [Ignore("https://github.com/unitycontainer/container/issues/140")]
#endif
        [TestProperty(OVERRIDE, nameof(DependencyOverride))]
        [DataTestMethod, DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public void Dependency_ByType_InGraph(string test, Type type, object defaultValue,
                                                              object defaultAttr, object registered, object named,
                                                              object injected, object overridden, object @default)
            => Assert_Consumer(type, new DependencyOverride(type, overridden), overridden, overridden);

        #endregion
    }
}
