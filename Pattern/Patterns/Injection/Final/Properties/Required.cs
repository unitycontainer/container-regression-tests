using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Injection.Properties
{
    [TestClass]
    public partial class Required : Injection.Required.Pattern
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
