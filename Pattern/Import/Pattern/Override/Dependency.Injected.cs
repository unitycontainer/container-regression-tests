using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unity.Injection;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class Pattern 
    {
        #region Type

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByType_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter()),
                               new DependencyOverride(type, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByType_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter(Name)),
                               new DependencyOverride(type, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByType_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                              InjectionMember_Value(new InjectionParameter(injected)),
                              new DependencyOverride(typeof(Pattern), overridden),
                              injected);
        #endregion


        #region Name

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByName_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                              InjectionMember_Value(injected),
                              new DependencyOverride((string)null, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByName_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter(Name)),
                               new DependencyOverride(Name, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByName_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Registered(BaselineTestNamed.MakeGenericType(type),
                                 InjectionMember_Value(new ResolvedParameter(Name)),
                                 new DependencyOverride((string)null, overridden), named);
        #endregion


        #region Contract

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByContract_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter()),
                               new DependencyOverride(type, null, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByContract_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                               InjectionMember_Value(new ResolvedParameter(Name)),
                               new DependencyOverride(type, Name, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OverrideInjected_ByContract_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Registered(BaselineTestType.MakeGenericType(type),
                           new DependencyOverride(type, Name, overridden),
                           registered, @default);
        #endregion
    }
}
