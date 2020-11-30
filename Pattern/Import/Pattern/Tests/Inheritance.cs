using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Common
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Inherited_Import(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => AssertUnresolvableImport(CorrespondingTypeDefinition, type, registered);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Inherited_Twice(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => AssertUnresolvableImport(CorrespondingTypeDefinition, type, registered);
    }
}
