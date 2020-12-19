using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Constructors.Compiled
{
    [TestClass]
    public class Selecting_Implicit : Constructors.Selecting_Implicit
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Selecting_Implicit_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Constructors.Selecting_Implicit).FullName);

        #endregion
    }

    [TestClass]
    public class Selecting_Annotated : Constructors.Selecting_Annotated
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.AddNewExtension<ForceCompillation>();
        }

        [ClassInitialize]
        public static void Selecting_Annotated_Activated_Initialize(TestContext _)
            => PatternBaseInitialize(typeof(Constructors.Selecting_Annotated).FullName);

        #endregion
    }
}
