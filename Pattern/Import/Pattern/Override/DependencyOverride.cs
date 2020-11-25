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
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Implicit_DependencyOverride(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                         bool isResolveble)
            => TestWithOverride(ImplicitImportType, type,
                new DependencyOverride(type, overridden),
                overridden, overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_DependencyOverride(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                         bool isResolveble)
            => TestWithOverride(RequiredImportType, type,
                new DependencyOverride(type, overridden),
                overridden, overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void Optional_DependencyOverride(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                         bool isResolveble)
            => TestWithOverride(OptionalImportType, type,
                new DependencyOverride(type, overridden),
                overridden, overridden);


        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Implicit_DownTheLine_DependencyOverride(string test, Type type,
                                                                    object @default, object defaultAttr,
                                                                    object registered, object named,
                                                                    object injected, object overridden,
                                                                    bool isResolveble) 
            => TestDownTheLineImportWithOverride(_implicitDownTheLine.MakeGenericType(type), 
                new DependencyOverride(type, overridden), overridden);


        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_DownTheLine_DependencyOverride(string test, Type type,
                                                                    object @default, object defaultAttr,
                                                                    object registered, object named,
                                                                    object injected, object overridden,
                                                                    bool isResolveble)
            => TestDownTheLineImportWithOverride(_requiredDownTheLine.MakeGenericType(type),
                new DependencyOverride(type, overridden), overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(PatternBase))]
        public virtual void Optional_DownTheLine_DependencyOverride(string test, Type type,
                                                                    object @default, object defaultAttr,
                                                                    object registered, object named,
                                                                    object injected, object overridden,
                                                                    bool isResolveble)
            => TestDownTheLineImportWithOverride(_optionalDownTheLine.MakeGenericType(type),
                new DependencyOverride(type, overridden), overridden);
    }
}
