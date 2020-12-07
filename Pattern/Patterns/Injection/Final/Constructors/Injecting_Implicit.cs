﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Constructors
{
    [TestClass]
    public partial class Injecting_Implicit : Injection.Implicit.Pattern
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


        #region Not Supported

        public override void Inject_Default(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void Inject_Named_Default(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }

        #endregion
    }
}