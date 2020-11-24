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
    /// Container.RegisterType(target, new InjectionConstructor(new OptionalParameter(...)), 
    ///                                new InjectionMethod("Method", new OptionalParameter(...)) , 
    ///                                new InjectionField("Field", new OptionalParameter(...)), 
    ///                                new InjectionProperty("Property", new OptionalParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Implicit

#if !UNITY_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Implicit_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(ImplicitImportType, type,
                InjectionMember_Value(new OptionalParameter()), registered);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Implicit_WithContractType(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(ImplicitImportType, type,
                InjectionMember_Value(new OptionalParameter(type)), registered);

#if !UNITY_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Implicit_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(ImplicitImportType, type,
                InjectionMember_Value(new OptionalParameter(Name)), named);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Implicit_WithContract(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(ImplicitImportType, type,
                InjectionMember_Value(new OptionalParameter(type, Name)), named);

        #endregion


        #region Required

#if !UNITY_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Required_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(RequiredImportType, type,
                InjectionMember_Value(new OptionalParameter()), registered);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Required_WithContractType(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(RequiredImportType, type,
                InjectionMember_Value(new OptionalParameter(type)), registered);

#if !UNITY_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Required_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(RequiredImportType, type,
                InjectionMember_Value(new OptionalParameter(Name)), named);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Required_WithContract(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(RequiredImportType, type,
                InjectionMember_Value(new OptionalParameter(type, Name)), named);

        #endregion


        #region Optional

#if !UNITY_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Optional_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(OptionalImportType, type,
                InjectionMember_Value(new OptionalParameter()), registered);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Optional_WithContractType(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(OptionalImportType, type,
                InjectionMember_Value(new OptionalParameter(type)), registered);

#if !UNITY_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Optional_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(OptionalImportType, type,
                InjectionMember_Value(new OptionalParameter(Name)), named);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void ByOptionalParameter_Optional_WithContract(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestOptionalImport(OptionalImportType, type,
                InjectionMember_Value(new OptionalParameter(type, Name)), named);

        #endregion
    }
}
