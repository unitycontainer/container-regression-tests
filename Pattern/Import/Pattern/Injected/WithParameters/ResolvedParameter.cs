using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Regression.Injected
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
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Implicit_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Value(new ResolvedParameter()), registered);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Implicit_WithContractType(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Value(new ResolvedParameter(type)), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Implicit_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Value(new ResolvedParameter(Name)), named);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Implicit_WithContract(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Value(new ResolvedParameter(type, Name)), named);

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Required_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Value(new ResolvedParameter()), registered);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Required_WithContractType(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Value(new ResolvedParameter(type)), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Required_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Value(new ResolvedParameter(Name)), named);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Required_WithContract(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Value(new ResolvedParameter(type, Name)), named);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Optional_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Value(new ResolvedParameter()), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Optional_WithContractType(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Value(new ResolvedParameter(type)), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Optional_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Value(new ResolvedParameter(Name)), named);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolvedParameter_Optional_WithContract(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Value(new ResolvedParameter(type, Name)), named);
        #endregion
    }
}
