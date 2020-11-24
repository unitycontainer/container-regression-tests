using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Regression.Override
{
    public abstract partial class Pattern 
    {
        [DataTestMethod]
        [DynamicData(nameof(Import_Optional_Data), typeof(PatternBase))]
        public virtual void Implicit_With_DependencyOverride(string test, Type type,
                                                             object @default, object defaultAttr,
                                                             object registered, object named,
                                                             object injected, object overridden,
                                                             bool isResolveble)
            => TestWithOverride(ImplicitImportType, type,
                new DependencyOverride(type, overridden),
                overridden, overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Implicit_With_MemberOverride(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestWithOverride(ImplicitImportType, type,
                Override_MemberOverride(DependencyName, overridden),
                overridden, overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Implicit_With_ParameterType(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                        bool isResolveble)
            => TestWithOverride(ImplicitImportType, type,
                Override_MemberOverride_WithType(type, DependencyName, overridden),
                overridden, overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Implicit_With_TargetType(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
            => TestWithOverrideOnType(ImplicitImportType, type,
                Override_MemberOverride_WithType(type, DependencyName, overridden),
                overridden, overridden);
    }
}
