using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Implicit
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Inherited_Import(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(_inherited, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Inherited_Twice(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(_twice, type, registered);
    }
}
