using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Dependency.Implicit
{
    public abstract partial class Pattern : Dependency.Pattern
    {
        #region Ignored

        public override void Named_ByType(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }

        public override void Parameter_Override_ByNameType(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }

        #endregion


        #region MemberOverride

        [DataTestMethod, DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public override void Member_OnType(string test, Type type, object defaultValue,
                                           object defaultAttr, object registered, object named,
                                           object injected, object overridden, object @default)

            => Assert_Consumer(type, MemberOverride(overridden).OnType(BaselineTestType.MakeGenericType(type)),
                               overridden, registered);

        #endregion
    }
}
