using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Regression
{
    /// <summary>
    /// Tests injecting dependencies by resolver or resolver factory
    /// </summary>
    /// <remarks>
    /// A resolver is an object that implements "IResolve" interface
    /// </remarks>
    /// <example>
    /// Container.RegisterType(target, new InjectionConstructor(resolver), 
    ///                                new InjectionMethod("Method", resolver) , 
    ///                                new InjectionField("Field", resolver), 
    ///                                new InjectionProperty("Property", resolver));
    /// </example>
    public abstract partial class InjectedPattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolver_Implicit_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithDefaultValue("Implicit", "BaselineTestType`1", type,
                InjectionMember_Value(new ValidatingResolver(injected)), injected, injected);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolver_Implicit_WithResolverFactory(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithDefaultValue("Implicit", "BaselineTestType`1", type,
                InjectionMember_Value(new ValidatingResolverFactory(injected)), injected, injected);

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolver_Required_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithDefaultValue("Annotated", "Required.BaselineTestType`1", type,
                InjectionMember_Value(new ValidatingResolver(injected)), injected, injected);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByResolver_Required_WithResolverFactory(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithDefaultValue("Annotated", "Required.BaselineTestType`1", type,
                InjectionMember_Value(new ValidatingResolverFactory(injected)), injected, injected);

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolver_Optional_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithDefaultValue("Annotated", "Optional.BaselineTestType`1", type,
                InjectionMember_Value(new ValidatingResolver(injected)), injected, injected);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByResolver_Optional_WithResolverFactory(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithDefaultValue("Annotated", "Optional.BaselineTestType`1", type,
                InjectionMember_Value(new ValidatingResolverFactory(injected)), injected, injected);

        #endregion
    }
}
