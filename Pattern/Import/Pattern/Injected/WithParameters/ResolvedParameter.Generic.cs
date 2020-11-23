using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Regression
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
    public abstract partial class InjectedPattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Implicit_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency")), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Implicit_WithName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency", Name)), named);

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Required_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency")), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Required_WithName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency", Name)), named);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Optional_Default(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency")), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByGenericParameter_Optional_WithName(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Value(new GenericParameter("TDependency", Name)), named);

        #endregion
    }
}
