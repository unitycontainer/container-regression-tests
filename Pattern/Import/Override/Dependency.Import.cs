using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByType_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                              new DependencyOverride(type, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByType_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                              new DependencyOverride(type, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByType_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Registered(BaselineTestType.MakeGenericType(type),
                           new DependencyOverride(typeof(Pattern), overridden),
                           registered, @default);


        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByType_InGraph(string test, Type type, object defaultValue,
                                                              object defaultAttr, object registered, object named,
                                                              object injected, object overridden, object @default)
            => Assert_Registered(BaselineConsumer.MakeGenericType(type),
                               new DependencyOverride(type, overridden),
                               overridden, overridden);
        #endregion


        #region Name

#if !UNITY_V4

#if !BEHAVIOR_V5
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByNullName(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                              new DependencyOverride((string)null, overridden), overridden);
#endif


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByName_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                              new DependencyOverride(Name, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByName_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Registered(BaselineTestType.MakeGenericType(type),
                           new DependencyOverride(Name, overridden),
                           registered, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByName_InGraph(string test, Type type, object defaultValue,
                                                              object defaultAttr, object registered, object named,
                                                              object injected, object overridden, object @default)
            => Assert_Registered(BaselineConsumer.MakeGenericType(type),
                               new DependencyOverride((string)null, overridden),
                               overridden, named);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByName_InReverse(string test, Type type, object defaultValue,
                                                                    object defaultAttr, object registered, object named,
                                                                    object injected, object overridden, object @default)
            => Assert_Registered(BaselineConsumer.MakeGenericType(type),
                                 new DependencyOverride(Name, overridden),
                                 registered, overridden);
#endif
        #endregion


        #region Contract

#if !UNITY_V4
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByContract_UnNamed(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestType.MakeGenericType(type),
                              new DependencyOverride(type, null, overridden), overridden);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByContract_Named(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Override(BaselineTestNamed.MakeGenericType(type),
                              new DependencyOverride(type, Name, overridden), overridden);

        
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByContract_Ignored(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Registered(BaselineTestType.MakeGenericType(type),
                           new DependencyOverride(type, Name, overridden),
                           registered, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByContract_InGraph(string test, Type type, object defaultValue,
                                                              object defaultAttr, object registered, object named,
                                                              object injected, object overridden, object @default)
            => Assert_Registered(BaselineConsumer.MakeGenericType(type),
                                 new DependencyOverride(type, null, overridden),
                                 overridden, named);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OverrideDepend_ByContract_InReverse(string test, Type type, object defaultValue,
                                                                    object defaultAttr, object registered, object named,
                                                                    object injected, object overridden, object @default)
            => Assert_Registered(BaselineConsumer.MakeGenericType(type),
                                 new DependencyOverride(type, Name, overridden),
                                 registered, overridden);
#endif
        #endregion
    }
}
