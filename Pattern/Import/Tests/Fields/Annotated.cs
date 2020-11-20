using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fields
{
    [TestClass]
    public partial class Annotated : Regression.Annotated.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Unsupported

        public override void Annotated_Parameters(string name) { }

        #endregion
    }
}
