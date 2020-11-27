﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Manager;

namespace Registration
{
    [TestClass]
    public partial class BuiltIn : FixtureBase
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}
