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
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_ByName(string test, Type type,
                                            object @default, object defaultAttr,
                                            object registered, object named,
                                            object injected, object overridden,
                                            bool isResolveble)
            => TestImportWithOverride(OptionalImportType.MakeGenericType(type),
                                  Override_MemberOverride(DependencyName, overridden), overridden);

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_WithType(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
            => TestImportWithOverride(OptionalImportType.MakeGenericType(type),
                                  Override_MemberOverride_WithType(type, DependencyName, overridden), overridden);


        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_OnType(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
        {
            var target = OptionalImportType.MakeGenericType(type);

            TestImportWithOverride(target, Override_MemberOverride_OnType(target, type, DependencyName, overridden), overridden);
        }



        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_DownTheLine_ByName(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                        bool isResolveble)
        {
            var target = _optionalDownTheLine.MakeGenericType(type);

            TestDownTheLineImportWithOverride(target, Override_MemberOverride(DependencyName, overridden), overridden);
        }

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_DownTheLine_WithType(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                        bool isResolveble)
        {
            var target = _optionalDownTheLine.MakeGenericType(type);

            TestDownTheLineImportWithOverride(target, Override_MemberOverride_WithType(type, DependencyName, overridden), overridden);
        }

        [DataTestMethod]
        [DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_DownTheLine_OnTypw(string test, Type type,
                                                        object @default, object defaultAttr,
                                                        object registered, object named,
                                                        object injected, object overridden,
                                                        bool isResolveble)
        {
            var target = _optionalDownTheLine.MakeGenericType(type);

            TestDownTheLineImportWithOverride(target,
                Override_MemberOverride_OnType(OptionalImportType.MakeGenericType(type), type, DependencyName, overridden), overridden);
        }
    }
}
