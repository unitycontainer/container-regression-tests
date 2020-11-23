using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
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
        {
            TestWithDefaultValue("Implicit", "BaselineTestType`1", type, 
                InjectionMember_Value(injected), injected, injected);
        }

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Implicit_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
        {
            TestRequiredImport("Implicit", "BaselineTestType`1", type,
                InjectionMember_Value(new ResolvedParameter(type)), registered);
        }

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Required_WithValue(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            TestWithDefaultValue("Annotated", "Required.BaselineTestType`1", type,
                InjectionMember_Value(injected), injected, injected);
        }

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Required_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
        {
            TestRequiredImport("Annotated", "Required.BaselineTestType`1", type,
                InjectionMember_Value(new ResolvedParameter(type)), registered);
        }

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Optional_WithValue(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            TestWithDefaultValue("Annotated", "Optional.BaselineTestType`1", type,
                InjectionMember_Value(injected), injected, injected);
        }

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Optional_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
        {
            TestOptionalImport("Annotated", "Optional.BaselineTestType`1", type,
                InjectionMember_Value(new OptionalParameter(type)), registered);
        }

        #endregion
    }
}
