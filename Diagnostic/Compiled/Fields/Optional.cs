using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Fields.Compiled
{
    [TestClass]
    public partial class Resolving_Optional : Fields.Resolving_Optional
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Resolving_Optional_Activated_Initialize(TestContext _) 
            => PatternBaseInitialize(typeof(Fields.Resolving_Optional).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Optional_With_Optional : Fields.Injecting_Optional_With_Optional
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Injecting_Optional_With_Optional_Activated_Initialize(TestContext context) 
            => Injecting_Optional_With_Optional_Initialize(typeof(Fields.Injecting_Optional_With_Optional).FullName);

        #endregion
    }

    [TestClass]
    public partial class Injecting_Optional_With_Required : Fields.Injecting_Optional_With_Required
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Injecting_Optional_With_Required_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Fields.Injecting_Optional_With_Required).FullName);

        #endregion
    }
}
