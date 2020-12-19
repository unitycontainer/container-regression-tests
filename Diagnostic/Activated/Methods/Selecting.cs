﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Methods.Activated
{
    [TestClass]
    public class Selecting_Annotated : Methods.Selecting_Annotated
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceActivation>();
        }

        [ClassInitialize]
        public static void Selecting_Annotated_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Methods.Selecting_Annotated).FullName);

        #endregion
    }
}
