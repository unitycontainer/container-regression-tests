using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Implicit
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Array(string test, Type type, object @default, object defaultAttr, object registered, 
                                  object named, object injected, object overridden, bool isResolveble)
            => TestArrayImport(ImplicitArrayType, type);

#if !BEHAVIOR_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Enumerable(string test, Type type, object @default, object defaultAttr, object registered, 
                                       object named, object injected, object overridden, bool isResolveble)
            => TestEnumerableImport(ImplicitImportType, type);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Lazy(string test, Type type, object @default, object defaultAttr, object registered, 
                                 object named, object injected, object overridden, bool isResolveble)
            => TestLazyImport(ImplicitImportType, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Func(string test, Type type, object @default, object defaultAttr, object registered, 
                                 object named, object injected, object overridden, bool isResolveble)
            => TestFuncImport(ImplicitImportType, type, registered);
    }
}
