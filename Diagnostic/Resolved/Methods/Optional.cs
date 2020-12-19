using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Methods.Resolved
{
    [TestClass]
    public partial class Resolving_Optional : Methods.Resolving_Optional
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
            => PatternBaseInitialize(typeof(Methods.Resolving_Optional).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Optional : Methods.Injecting_Optional
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceResolution>();
        }

        [ClassInitialize]
        public static void Injecting_Optional_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Methods.Injecting_Optional).FullName);

        #endregion
    }
}
