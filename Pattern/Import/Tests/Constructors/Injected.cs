using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Constructors
{
    [TestClass]
    public partial class Injected : InjectedPattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
