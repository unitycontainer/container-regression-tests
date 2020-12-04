using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Implicit
{
    public abstract partial class Pattern : Import.Pattern
    {
        #region On Named not supported

        public override void Import_ByType_Named(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }


        public override void Optional_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByType_InGraph(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#if !UNITY_V4
        public override void OverrideDepend_ByName_Named(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByName_InGraph(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default){ }
        public override void OverrideDepend_ByName_InReverse(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByContract_Named(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByContract_InGraph(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByContract_InReverse(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }

        public override void Resolved_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void Optional_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#endif
        #endregion
    }
}
