using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Import.Injected
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
        #region Implicit

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByOptionalGenericParameter_Implicit_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalGeneric(ImplicitImportType, type,
                InjectionMember_Value(new OptionalGenericParameter(TDependency)), registered);

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByOptionalGenericParameter_Implicit_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalGeneric(ImplicitImportType, type,
                InjectionMember_Value(new OptionalGenericParameter(TDependency, Name)), named);

        #endregion


        #region Required

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByOptionalGenericParameter_Required_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalGeneric(RequiredImportType, type,
                InjectionMember_Value(new OptionalGenericParameter(TDependency)), registered);

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByOptionalGenericParameter_Required_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalGeneric(RequiredImportType, type,
                InjectionMember_Value(new OptionalGenericParameter(TDependency, Name)), named);

        #endregion


        #region Optional

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByOptionalGenericParameter_Optional_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalGeneric(OptionalImportType, type,
                InjectionMember_Value(new OptionalGenericParameter(TDependency)), registered);

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByOptionalGenericParameter_Optional_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalGeneric(OptionalImportType, type,
                InjectionMember_Value(new OptionalGenericParameter(TDependency, Name)), named);

        #endregion
    }
}
