using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Import.Implicit
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Import.Pattern))]
        public override void Import_ByType_Named(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type), registered);
    }
}
