using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Regression
{
    /// <summary>
    /// Tests injecting dependencies by value
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionConstructor(15), 
    ///                                new InjectionMethod("Method", 15) , 
    ///                                new InjectionField("Field", 15), 
    ///                                new InjectionProperty("Property", 15));
    /// </example>
    public abstract partial class InjectedPattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Implicit_WithValue(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestWithDefaultValue(ImplicitImportType, type,
                InjectionMember_Value(injected), injected, injected);

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Required_WithValue(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestWithDefaultValue(RequiredImportType, type,
                InjectionMember_Value(injected), injected, injected);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Optional_WithValue(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble) 
            => TestWithDefaultValue(OptionalImportType, type,
                InjectionMember_Value(injected), injected, injected);

        #endregion
    }
}
