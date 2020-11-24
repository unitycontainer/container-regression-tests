using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Methods
{
    [TestClass]
    public partial class Injected : Regression.Injected.Pattern
    {
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
