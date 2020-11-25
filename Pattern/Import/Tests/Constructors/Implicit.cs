using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Import.Constructors
{
    [TestClass]
    public partial class Implicit : Import.Implicit.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
