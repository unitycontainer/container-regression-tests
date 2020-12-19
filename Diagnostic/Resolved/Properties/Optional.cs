﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Properties.Resolved
{
    [TestClass]
    public partial class Resolving_Optional : Properties.Resolving_Optional
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceResolution>();
        }

        [ClassInitialize]
        public static void Resolving_Optional_Activated_Initialize(TestContext _) 
            => PatternBaseInitialize(typeof(Properties.Resolving_Optional).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Optional_With_Optional : Properties.Injecting_Optional_With_Optional
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceResolution>();
        }

        [ClassInitialize]
        public static void Injecting_Optional_With_Optional_Activated_Initialize(TestContext context) 
            => Injecting_Optional_With_Optional_Initialize(typeof(Properties.Injecting_Optional_With_Optional).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Optional_With_Required : Properties.Injecting_Optional_With_Required
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceResolution>();
        }

        [ClassInitialize]
        public static void Injecting_Optional_With_Required_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Properties.Injecting_Optional_With_Required).FullName);

        #endregion
    }
}
