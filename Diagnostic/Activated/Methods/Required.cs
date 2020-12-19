using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Methods.Activated
{
    [TestClass]
    public partial class Resolving_Required : Methods.Resolving_Required
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceActivation>();
        }

        [ClassInitialize]
        public static void Resolving_Required_Activated_Initialize(TestContext _) 
            => PatternBaseInitialize(typeof(Methods.Resolving_Required).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Required : Methods.Injecting_Required
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceActivation>();
        }

        [ClassInitialize]
        public static void Injecting_Required_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Methods.Injecting_Required).FullName);

        #endregion
    }
}
