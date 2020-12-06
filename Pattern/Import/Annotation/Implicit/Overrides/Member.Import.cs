using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Import.Implicit
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Member_OnType(string test, Type type, object defaultValue,
                                                                  object defaultAttr, object registered, object named,
                                                                  object injected, object overridden, object @default)
            => Assert_Consumer(type, MemberOverride(overridden).OnType(BaselineTestType.MakeGenericType(type)), 
                overridden, registered);
    }
}
