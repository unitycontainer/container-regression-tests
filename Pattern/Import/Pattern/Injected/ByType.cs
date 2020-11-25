using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Injected
{
    /// <summary>
    /// Tests injecting dependencies by type
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionConstructor(type), 
    ///                                new InjectionMethod("Method", type) , 
    ///                                new InjectionField("Field", type), 
    ///                                new InjectionProperty("Property", type));
    /// </example>
    public abstract partial class Pattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByType_Implicit_WithRequired(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Required_ByType(type), registered);


        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByType_Implicit_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestOptionalImport(ImplicitImportType, type,
                InjectionMember_Optional_ByType(type), registered);

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByType_Required_WithRequired(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Required_ByType(type), registered);


        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByType_Required_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestOptionalImport(RequiredImportType, type,
                InjectionMember_Optional_ByType(type), registered);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByType_Optional_WithRequired(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Required_ByType(type), registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void ByType_Optional_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestOptionalImport(OptionalImportType, type,
                InjectionMember_Optional_ByType(type), registered);

        #endregion
    }
}
