using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Properties
{
    [TestClass]
    public class Selecting_Optional : Selection.Pattern
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
