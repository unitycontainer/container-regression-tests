using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Properties
{
    [TestClass]
    public partial class Required : Import.Required.Pattern
    {
        #region Properties

        protected override string DependencyName => "Property";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
