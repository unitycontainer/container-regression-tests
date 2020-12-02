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
        [ExpectedException(typeof(ResolutionFailedException))]
        [DataTestMethod, DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        public virtual void Throws_OnRefParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Ref`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }

        [ExpectedException(typeof(ResolutionFailedException))]
        [DataTestMethod, DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        public virtual void Throws_OnOutParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Out`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }


        #region OnNamed Not Supported

        public override void OptionalParameter_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        
        public override void OverrideDepend_ByType_InGraph(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#if !UNITY_V4
        public override void OverrideDepend_ByName_Named(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByName_InGraph(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default){ }
        public override void OverrideDepend_ByName_InReverse(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByContract_Named(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByContract_InGraph(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void OverrideDepend_ByContract_InReverse(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#endif
        #endregion
    }
}
