using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Selection.Properties
{
    [TestClass]
    public partial class Injected : Selection.Injected.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Unsupported Tests

        public override void DefaultMemberImplicit(Type dependency, Type @default) { }
        public override void DefaultMemberImplicitGeneric(Type dependency, Type @default) { }
        public override void DefaultMemberOptional(Type dependency, Type @default) { }
        public override void DefaultMemberOptionalGeneric(Type dependency, Type @default) { }
        public override void DefaultMemberRequired(Type dependency, Type @default) { }
        public override void DefaultMemberRequiredGeneric(Type dependency, Type @default) { }

        #endregion
    }
}
