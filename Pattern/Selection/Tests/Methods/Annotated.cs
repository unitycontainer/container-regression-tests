using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selection.Methods
{
    [TestClass]
    public partial class Annotated : Selection.Annotated.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
