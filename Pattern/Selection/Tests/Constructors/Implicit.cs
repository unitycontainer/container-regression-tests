using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Constructors
{
    [TestClass]
    public partial class Implicit : Selection.Implicit.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Test Overrides

        [DataTestMethod]
        [DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public override void NoPublicMebersToSelect(string test, Type type) 
            => base.NoPublicMebersToSelect(test, type);

        #endregion
    }
}
