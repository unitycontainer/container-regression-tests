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
    /// Container.RegisterType(target, new InjectionConstructor(new OptionalGenericParameter(...)), 
    ///                                new InjectionMethod("Method", new OptionalGenericParameter(...)) , 
    ///                                new InjectionField("Field", new OptionalGenericParameter(...)), 
    ///                                new InjectionProperty("Property", new OptionalGenericParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Default
#if !UNITY_V4
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency)), registered, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency)), named, @default);
#endif
        #endregion


        #region Type
        // TODO: Implementation?
        /*

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => InjectedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, type)), registered, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => InjectedNamedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, type)), registered, @default);
        */
        #endregion


        #region Name

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, Name)), named, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, (string)null)), registered, @default);

        #endregion


        #region Contract

        // TODO: Implementation?
        /*
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => InjectedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, type, Name)), named, @default);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void OptionalGenericParameter_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => InjectedNamedGenericOrDefault(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, type, null)), registered, @default);
        */
        #endregion
    }
}
