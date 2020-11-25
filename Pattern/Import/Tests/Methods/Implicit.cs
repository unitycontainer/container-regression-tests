using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Import.Methods
{
    [TestClass]
    public partial class Implicit : Import.Implicit.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Unsupported
        //#if !V4
        //        // Constructors cann't be injected by name
        //        public override void Injected_ByName(string test, Type type, string name, Type dependency, object expected) { }
        //        public override void Injected_ByName_Required(string test, Type type, string name, Type dependency, object expected) { }
        //        public override void Injected_ByName_Optional(string test, Type type, string name, Type dependency, object expected) { }
        //        public override void Injected_ByName_Default(string test, Type type, string name, Type dependency, object expected) { }
        //#endif
        #endregion
    }
}
