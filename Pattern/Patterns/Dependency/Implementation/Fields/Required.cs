﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;

namespace Fields
{
    [TestClass]
    public partial class Resolving_Required : Dependency.Required.Pattern
    {
        #region Properties

        protected override string DependencyName => "Field";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void Resolving_Required_Initialize(TestContext context) 
            => PatternBaseInitialize(context.FullyQualifiedTestClassName);

        #endregion
    }
}
