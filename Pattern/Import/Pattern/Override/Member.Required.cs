using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Import.Override
{
    public abstract partial class Pattern 
    {
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_ByName(string test, Type type,
                                            object @default, object defaultAttr,
                                            object registered, object named,
                                            object injected, object overridden,
                                            bool isResolveble)
            => TestImportWithOverride(RequiredImportType.MakeGenericType(type),
                                  Override_MemberOverride(DependencyName, overridden), overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_WithType(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
            => TestImportWithOverride(RequiredImportType.MakeGenericType(type),
                                  Override_MemberOverride_WithType(type, DependencyName, overridden), overridden);


        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_OnType(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
        {
            var target = RequiredImportType.MakeGenericType(type);

            TestImportWithOverride(target, Override_MemberOverride_OnType(target, type, DependencyName, overridden), overridden);
        }


        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_DownTheLine_ByName(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                        bool isResolveble)
        {
            var target = _requiredDownTheLine.MakeGenericType(type);

            TestDownTheLineImportWithOverride(target, Override_MemberOverride(DependencyName, overridden), overridden);
        }

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_DownTheLine_WithType(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                        bool isResolveble)
        {
            var target = _requiredDownTheLine.MakeGenericType(type);

            TestDownTheLineImportWithOverride(target, Override_MemberOverride_WithType(type, DependencyName, overridden), overridden);
        }

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_DownTheLine_OnTypw(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                        bool isResolveble)
        {
            var target = _requiredDownTheLine.MakeGenericType(type);

            TestDownTheLineImportWithOverride(target,
                Override_MemberOverride_OnType(RequiredImportType.MakeGenericType(type), type, DependencyName, overridden), overridden);
        }
    }
}
