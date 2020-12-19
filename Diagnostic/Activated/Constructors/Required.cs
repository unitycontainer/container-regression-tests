using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Constructors.Activated
{
    [TestClass]
    public partial class Resolving_Required : Constructors.Resolving_Required
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
            => PatternBaseInitialize(typeof(Constructors.Resolving_Required).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Required : Constructors.Injecting_Required
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
            => PatternBaseInitialize(typeof(Constructors.Injecting_Required).FullName);

        #endregion
    }
}
