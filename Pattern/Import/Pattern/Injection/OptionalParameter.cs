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
    /// Container.RegisterType(target, new InjectionConstructor(new OptionalParameter(...)), 
    ///                                new InjectionMethod("Method", new OptionalParameter(...)) , 
    ///                                new InjectionField("Field", new OptionalParameter(...)), 
    ///                                new InjectionProperty("Property", new OptionalParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Default
#if !UNITY_V4
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new OptionalParameter()), registered, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamed(type,
                InjectionMember_Value(new OptionalParameter()), named, @default);
#endif
        #endregion


        #region Type

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new OptionalParameter(type)), registered, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamed(type, InjectionMember_Value(new OptionalParameter(type)), registered, @default);

        #endregion


        #region Name

#if !UNITY_V4
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new OptionalParameter(Name)), named, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamed(type, InjectionMember_Value(new OptionalParameter((string)null)), registered, @default);
#endif

        #endregion


        #region Contract

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(type, InjectionMember_Value(new OptionalParameter(type, Name)), named, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalParameter_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamed(type, InjectionMember_Value(new OptionalParameter(type, null)), registered, @default);
        
        #endregion
    }
}
