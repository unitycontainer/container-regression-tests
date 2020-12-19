using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Fields.Compiled
{
    [TestClass]
    public class Selecting_Annotated : Fields.Selecting_Annotated
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
            => PatternBaseInitialize(typeof(Fields.Selecting_Annotated).FullName);

        #endregion
    }
}
