using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Methods
{
    [TestClass]
    public partial class Override : Regression.Override.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        protected override string DependencyName => "value";

        protected override Type GetImportType(Type type) 
            => type.GetMethod(Support.MethodName)
                   .GetParameters()
                   .First(p => p.Name.Equals(DependencyName))
                   .ParameterType;

        #endregion


        #region Not Supported in Unity v4

#if UNITY_V4
        public override void Implicit_With_MemberOverride(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
        public override void Implicit_With_ParameterType(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
        public override void Implicit_With_TargetType(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
#endif

        #endregion
    }
}
