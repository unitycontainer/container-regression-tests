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
    /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(...)), 
    ///                                new InjectionMethod("Method", new InjectionParameter(...)) , 
    ///                                new InjectionField("Field", new InjectionParameter(...)), 
    ///                                new InjectionProperty("Property", new InjectionParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Implicit_WithValue(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(ImplicitImportType, type,
                InjectionMember_Value(new InjectionParameter(injected)), injected, injected);

#if !BEHAVIOR_V4 && !BEHAVIOR_V5
        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Implicit_WithParameter(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            // Legacy Unity did not support nesting with more than one level
            => TestRequiredImport(ImplicitImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ResolvedParameter(type))), registered);
#endif

#if !UNITY_V4 && !BEHAVIOR_V5
        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Implicit_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(ImplicitImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ValidatingResolver(injected))), 
                injected, injected);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Implicit_WithResolverFactory(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(ImplicitImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ValidatingResolverFactory(injected))), 
                injected, injected);
#endif

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Required_WithValue(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(RequiredImportType, type,
                InjectionMember_Value(new InjectionParameter(injected)),
                injected, injected);

#if !BEHAVIOR_V4 && !BEHAVIOR_V5
        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Required_WithParameter(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(RequiredImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ResolvedParameter(type))), registered);
#endif

#if !UNITY_V4 && !BEHAVIOR_V5

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Required_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(RequiredImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ValidatingResolver(injected))), 
                injected, injected);

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Required_WithResolverFactory(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(RequiredImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ValidatingResolverFactory(injected))),
                injected, injected);
#endif

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Optional_WithValue(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(OptionalImportType, type,
                InjectionMember_Value(new InjectionParameter(injected)),
                injected, injected);

#if !BEHAVIOR_V4 && !BEHAVIOR_V5
        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Optional_WithParameter(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestRequiredImport(OptionalImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ResolvedParameter(type))), registered);
#endif

#if !UNITY_V4 && !BEHAVIOR_V5
        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Optional_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(OptionalImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ValidatingResolver(injected))),
                injected, injected);

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByInjectionParameter_Optional_WithResolverFactory(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
            => TestWithProvidedValue(OptionalImportType, type,
                InjectionMember_Value(new InjectionParameter(type, new ValidatingResolverFactory(injected))),
                injected, injected);
#endif

        #endregion
    }
}
