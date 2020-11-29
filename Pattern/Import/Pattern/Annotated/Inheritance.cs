using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Annotated
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Required_Inherited(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(_requiredInherited, type, registered);
        
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Required_Inherited_Twice(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(_requiredTwice, type, registered);

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_Inherited(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestOptionalImport(_optionalInherited, type, registered);

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Optional_Inherited_Twice(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestOptionalImport(_optionalTwice, type, registered);
    }
}
