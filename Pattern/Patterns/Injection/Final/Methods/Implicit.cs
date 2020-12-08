using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Methods
{
    [TestClass]
    public partial class Implicit_Injecting : Injection.Implicit.Pattern
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


        #region Special Cases

        #endregion
    }
}
