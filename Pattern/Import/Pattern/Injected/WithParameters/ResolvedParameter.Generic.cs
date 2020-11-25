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
    /// Container.RegisterType(target, new InjectionConstructor(new GenericParameter(...)), 
    ///                                new InjectionMethod("Method", new GenericParameter(...)) , 
    ///                                new InjectionField("Field", new GenericParameter(...)), 
    ///                                new InjectionProperty("Property", new GenericParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Implicit_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredGeneric(ImplicitImportType, type,
                InjectionMember_Value(new GenericParameter(TDependency)), registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Implicit_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredGeneric(ImplicitImportType, type,
                InjectionMember_Value(new GenericParameter(TDependency, Name)), named);

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Required_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredGeneric(RequiredImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency")), registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Required_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredGeneric(RequiredImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency", Name)), named);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Optional_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredGeneric(OptionalImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency")), registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Optional_WithContractName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredGeneric(OptionalImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency", Name)), named);

        #endregion
    }
}
