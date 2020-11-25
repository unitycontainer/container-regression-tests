using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Injected
{
    /// <summary>
    /// Tests injecting dependencies by member name
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionMethod("Method") , 
    ///                                new InjectionField("Field"), 
    ///                                new InjectionProperty("Property"));
    /// </example>
    public abstract partial class Pattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void ByName_Implicit_WithRequired(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport(ImplicitImportType, type, 
                InjectionMember_Required_ByName(type), registered);


        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void ByName_Implicit_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestOptionalImport(ImplicitImportType, type,
                InjectionMember_Optional_ByName(type), registered);


        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void ByName_Required_WithRequired(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Required_ByName(type), registered);


        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void ByName_Required_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestOptionalImport(RequiredImportType, type,
                InjectionMember_Optional_ByName(type), registered);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void ByName_Optional_WithRequired(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Required_ByName(type), registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void ByName_Optional_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestOptionalImport(OptionalImportType, type,
                InjectionMember_Optional_ByName(type), registered);

        #endregion
    }
}
