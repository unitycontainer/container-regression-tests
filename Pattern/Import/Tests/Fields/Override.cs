using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fields
{
    [TestClass]
    public partial class Override : Regression.Override.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        protected override string DependencyName => "Field";

        protected override Type GetImportType(Type type) 
            => type.GetField(DependencyName).FieldType;

        #endregion


        #region Not Supported

        public override void Implicit_ByName(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble)
        {
        }

        public override void Implicit_DependencyOverride(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble)
        {
        }

        public override void Implicit_OnType(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble)
        {
        }

        public override void Implicit_WithType(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble)
        {
        }

        #endregion
    }
}
