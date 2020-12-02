using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Import.Methods
{
    [TestClass]
    public partial class Required : Import.Required.Pattern
    {
        #region Properties
        protected override string DependencyName => "value";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
