﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Constructors
{
    [TestClass]
    public partial class Resolving_Optional : Dependency.Optional.Pattern
    {
        #region Properties
        protected override string DependencyName => "value";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void Resolving_Optional_Initialize(TestContext context) 
            => PatternBaseInitialize(context.FullyQualifiedTestClassName);

        #endregion
    }
}
