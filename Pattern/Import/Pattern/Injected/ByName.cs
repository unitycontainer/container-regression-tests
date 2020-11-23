using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Regression
{
    /// <summary>
    /// Tests injecting dependencies by member name
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionMethod("Method") , 
    ///                                new InjectionField("Field"), 
    ///                                new InjectionProperty("Property"));
    /// </example>
    public abstract partial class InjectedPattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByName_Implicit_WithRequired(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport("Implicit", "BaselineTestType`1", type, 
                InjectionMember_Required_ByName(type), registered);


        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByName_Implicit_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestOptionalImport("Implicit", "BaselineTestType`1", type,
                InjectionMember_Optional_ByName(type), registered);


        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByName_Required_WithRequired(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport("Annotated", "Required.BaselineTestType`1", type,
                InjectionMember_Required_ByName(type), registered);


        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByName_Required_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestOptionalImport("Annotated", "Required.BaselineTestType`1", type,
                InjectionMember_Optional_ByName(type), registered);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByName_Optional_WithRequired(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestRequiredImport("Annotated", "Optional.BaselineTestType`1", type,
                InjectionMember_Required_ByName(type), registered);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByName_Optional_WithOptional(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestOptionalImport("Annotated", "Optional.BaselineTestType`1", type,
                InjectionMember_Optional_ByName(type), registered);

        #endregion
    }
}
