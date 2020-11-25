using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Import.Fields
{
    [TestClass]
    public partial class Annotated : Import.Annotated.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
