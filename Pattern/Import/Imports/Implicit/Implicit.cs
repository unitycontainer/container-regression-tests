using System;

namespace Import.Implicit
{
    public abstract partial class Pattern : Import.Pattern
    {
        #region Unsupported
        public override void OptionalParameter_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OptionalParameter_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }

        #endregion
    }
}
