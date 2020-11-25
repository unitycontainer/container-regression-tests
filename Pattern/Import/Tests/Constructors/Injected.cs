using Microsoft.VisualStudio.TestTools.UnitTesting;
using Import;
using System;

namespace Import.Constructors
{
    [TestClass]
    public partial class Injected : Import.Injected.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
