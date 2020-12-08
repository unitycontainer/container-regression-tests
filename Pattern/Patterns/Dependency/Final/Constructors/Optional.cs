using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Constructors
{
    [TestClass]
    public partial class Optional_Resolving : Dependency.Optional.Pattern
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
