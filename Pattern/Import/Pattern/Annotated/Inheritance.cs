using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_Inherited(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(_requiredInherited, type, registered);
        
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_Inherited_Twice(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(_requiredTwice, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Optional_Inherited(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestOptionalImport(_optionalInherited, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Optional_Inherited_Twice(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestOptionalImport(_optionalTwice, type, registered);
    }
}
