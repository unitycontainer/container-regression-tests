using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Injection.Fields
{
    [TestClass]
    public partial class Optional : Injection.Optional.Pattern
    {
        #region Properties

        protected override string DependencyName => "Field";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
