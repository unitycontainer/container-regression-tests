using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Fields.Compiled
{
    [TestClass]
    public partial class Resolving_Required : Fields.Resolving_Required
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Resolving_Required_Activated_Initialize(TestContext _) 
            => PatternBaseInitialize(typeof(Fields.Resolving_Required).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Required_With_Optional : Fields.Injecting_Required_With_Optional
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Injecting_Required_With_Optional_Activated_Initialize(TestContext context) 
            => Injecting_Required_With_Optional_Initialize(typeof(Fields.Injecting_Required_With_Optional).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Required_With_Required : Fields.Injecting_Required_With_Required 
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Injecting_Required_With_Required_Activated_Initialize(TestContext context)
            => PatternBaseInitialize(typeof(Fields.Injecting_Required_With_Required).FullName);

        #endregion
    }
}
