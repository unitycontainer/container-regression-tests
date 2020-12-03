﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Import.Fields
{
    [TestClass]
    public partial class Optional : Import.Optional.Pattern
    {
        #region Properties

        protected override string DependencyName => "Field";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion
    }
}