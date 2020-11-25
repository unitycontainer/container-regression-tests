using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Regression.Override
{
    public abstract partial class Pattern 
    {
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Optional_ByName(string test, Type type,
                                            object @default, object defaultAttr,
                                            object registered, object named,
                                            object injected, object overridden,
                                            bool isResolveble)
            => TestImportWithOverride(OptionalImportType.MakeGenericType(type),
                                  Override_MemberOverride(DependencyName, overridden));

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Optional_WithType(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
            => TestImportWithOverride(OptionalImportType.MakeGenericType(type),
                                  Override_MemberOverride_WithType(type, DependencyName, overridden));


        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Optional_OnType(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
        {
            var target = OptionalImportType.MakeGenericType(type);

            TestImportWithOverride(target, Override_MemberOverride_OnType(target, type, DependencyName, overridden));
        }
    }
}
