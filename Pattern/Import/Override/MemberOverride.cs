using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class Pattern 
    {
        //[DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        //public virtual void MemberOverride_ByName(string test, Type type,
        //                                    object @default, object defaultAttr,
        //                                    object registered, object named,
        //                                    object injected, object overridden,
        //                                    bool isResolveble)
        //    => Assert_Override(type,  MemberOverride_WithName(DependencyName, overridden), overridden);

        //[DataTestMethod]
        //[DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        //public virtual void MemberOverride_ByType(string test, Type type,
        //                                             object @default, object defaultAttr,
        //                                             object registered, object named,
        //                                             object injected, object overridden,
        //                                             bool isResolveble)
        //    => TestImportWithOverride(BaselineTestType.MakeGenericType(type),
        //                          MemberOverride_WithContract(type, DependencyName, overridden), overridden);

        //[DataTestMethod]
        //[DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        //public virtual void MemberOverride_OnType(string test, Type type,
        //                                             object @default, object defaultAttr,
        //                                             object registered, object named,
        //                                             object injected, object overridden,
        //                                             bool isResolveble)
        //{
        //    var target = BaselineTestType.MakeGenericType(type);

        //    TestImportWithOverride(target, MemberOverride_WithContract_OnType(target, type, DependencyName, overridden), overridden);
        //}

        //[DataTestMethod]
        //[DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        //public virtual void Implicit_DownTheLine_ByName(string test, Type type,
        //                                                object @default, object defaultAttr,
        //                                                object registered, object named,
        //                                                object injected, object overridden,
        //                                                bool isResolveble)
        //{
        //    var target = _implicitDownTheLine.MakeGenericType(type);

        //    TestDownTheLineImportWithOverride(target, MemberOverride_WithName(DependencyName, overridden), overridden);
        //}

        //[DataTestMethod]
        //[DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        //public virtual void Implicit_DownTheLine_WithType(string test, Type type,
        //                                                object @default, object defaultAttr,
        //                                                object registered, object named,
        //                                                object injected, object overridden,
        //                                                bool isResolveble)
        //{
        //    var target = _implicitDownTheLine.MakeGenericType(type);

        //    TestDownTheLineImportWithOverride(target, MemberOverride_WithContract(type, DependencyName, overridden), overridden);
        //}

        //[DataTestMethod]
        //[DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        //public virtual void Implicit_DownTheLine_OnTypw(string test, Type type,
        //                                                object @default, object defaultAttr,
        //                                                object registered, object named,
        //                                                object injected, object overridden,
        //                                                bool isResolveble)
        //{
        //    var target = _implicitDownTheLine.MakeGenericType(type);

        //    TestDownTheLineImportWithOverride(target, 
        //        MemberOverride_WithContract_OnType(BaselineTestType.MakeGenericType(type), type, DependencyName, overridden), overridden);
        //}
    }
}
