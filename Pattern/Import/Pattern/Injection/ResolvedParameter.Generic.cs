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
    /// Container.RegisterType(target, new InjectionConstructor(new GenericParameter(...)), 
    ///                                new InjectionMethod("Method", new GenericParameter(...)) , 
    ///                                new InjectionField("Field", new GenericParameter(...)), 
    ///                                new InjectionProperty("Property", new GenericParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Default
#if !UNITY_V4
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency)), registered);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_NamedInjectedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency)), named);
#endif
        #endregion


        #region Type
        // TODO: Implementation?
        /*
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => AssertGenericInjected(type, InjectionMember_Value(new GenericParameter(TDependency, type)), registered);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => AssertNamedGenericInjected(type, InjectionMember_Value(new GenericParameter(TDependency, type)), registered);
        */
        #endregion


        #region Name

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency, Name)), named);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_NamedInjectedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency, (string)null)), registered);

        #endregion


        #region Contract

        // TODO: Implementation?
        /*
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => AssertGenericInjected(type, InjectionMember_Value(new GenericParameter(TDependency, type, Name)), named);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void GenericParameter_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => AssertNamedGenericInjected(type, InjectionMember_Value(new GenericParameter(TDependency, type, null)), registered);
        */
        #endregion
    }
}
