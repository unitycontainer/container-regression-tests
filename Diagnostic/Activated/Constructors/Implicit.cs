using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Constructors.Activated
{
    [TestClass]
    public partial class Resolving_Implicit : Constructors.Resolving_Implicit
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceActivation>();
        }

        [ClassInitialize]
        public static void Resolving_Implicit_Activated_Initialize(TestContext _) 
            => PatternBaseInitialize(typeof(Constructors.Resolving_Implicit).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Implicit : Constructors.Injecting_Implicit
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceActivation>();
        }

        [ClassInitialize]
        public static void Injecting_Implicit_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Constructors.Injecting_Implicit).FullName);

        #endregion
    }
}
