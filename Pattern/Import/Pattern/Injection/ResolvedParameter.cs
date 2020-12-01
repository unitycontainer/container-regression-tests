using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Import
{
    /// <summary>
    /// Tests injecting dependencies with InjectionParameter
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionConstructor(new ResolvedParameter(...)), 
    ///                                new InjectionMethod("Method", new ResolvedParameter(...)) , 
    ///                                new InjectionField("Field", new ResolvedParameter(...)), 
    ///                                new InjectionProperty("Property", new ResolvedParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Default
#if !UNITY_V4
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new ResolvedParameter()), registered);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedNamed(type, InjectionMember_Value(new ResolvedParameter()), named);
#endif
        #endregion


        #region Type

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new ResolvedParameter(type)), registered);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedNamed(type, InjectionMember_Value(new ResolvedParameter(type)), registered);

        #endregion


        #region Name

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new ResolvedParameter(Name)), named);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedNamed(type, InjectionMember_Value(new ResolvedParameter((string)null)), registered);

        #endregion


        #region Contract

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new ResolvedParameter(type, Name)), named);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ResolvedParameter_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedNamed(type, InjectionMember_Value(new ResolvedParameter(type, null)), registered);
        
        #endregion
    }
}
