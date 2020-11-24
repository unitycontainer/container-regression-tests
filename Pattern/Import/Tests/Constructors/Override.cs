using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Constructors
{
    [TestClass]
    public partial class Override : Regression.Override.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        protected override string DependencyName => "value";

        protected override Type GetImportType(Type type) 
            => type.GetConstructors()
                   .First()
                   .GetParameters()
                   .First(p => p.Name.Equals(DependencyName))
                   .ParameterType;

        #endregion
    }
}
