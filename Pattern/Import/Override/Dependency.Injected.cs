using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class Pattern 
    {
        #region Type

#if !UNITY_V4
        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByType_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter()),
                               new DependencyOverride(type, overridden), overridden);


        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByType_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter(Name)),
                               new DependencyOverride(type, overridden), overridden);
#endif

        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByType_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                              InjectionMember_Value(new InjectionParameter(injected)),
                              new DependencyOverride(typeof(Pattern), overridden),
                              injected);
        #endregion


        #region Name

#if !UNITY_V4
        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByName_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                              InjectionMember_Value(injected),
                              new DependencyOverride((string)null, overridden), overridden);


        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByName_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter(Name)),
                               new DependencyOverride(Name, overridden), overridden);


        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByName_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Registered(BaselineTestNamed.MakeGenericType(type),
                                 InjectionMember_Value(new ResolvedParameter(Name)),
                                 new DependencyOverride((string)null, overridden), named);
#endif
        #endregion


        #region Contract

#if !UNITY_V4
        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByContract_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter()),
                               new DependencyOverride(type, null, overridden), overridden);


        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByContract_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter(Name)),
                               new DependencyOverride(type, Name, overridden), overridden);


        [TestCategory(Category_Override)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideInjected_ByContract_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Registered(BaselineTestType.MakeGenericType(type),
                           new DependencyOverride(type, Name, overridden),
                           registered, @default);
#endif
        #endregion
    }
}
