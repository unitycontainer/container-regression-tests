using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Inherited_Import(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_Resolved(CorrespondingTypeDefinition.MakeGenericType(type), registered);


        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Inherited_Twice(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_Resolved(CorrespondingTypeDefinition.MakeGenericType(type), registered);
    }
}
