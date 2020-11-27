using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;

namespace Registration
{
    [TestClass]
    public partial class Collection : FixtureBase
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
