using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Constructors
{
    [TestClass]
    public partial class Injected : InjectedPattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Incompatible Tests

        public override void Injected_ByName_Implicit(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
        public override void Injected_ByName_Required(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
        public override void Injected_ByName_Optional(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }

        #endregion
    }
}
