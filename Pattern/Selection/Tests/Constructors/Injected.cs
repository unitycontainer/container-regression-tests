using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selection.Constructors
{
    [TestClass]
    public partial class Injected : Selection.Injected.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
