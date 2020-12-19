using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Methods.Resolved
{
    [TestClass]
    public partial class Resolving_Implicit : Methods.Resolving_Implicit
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceResolution>();
        }

        [ClassInitialize]
        public static void Resolving_Implicit_Activated_Initialize(TestContext _) 
            => PatternBaseInitialize(typeof(Methods.Resolving_Implicit).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Implicit : Methods.Injecting_Implicit
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceResolution>();
        }

        [ClassInitialize]
        public static void Injecting_Implicit_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Methods.Injecting_Implicit).FullName);

        #endregion
    }
}
