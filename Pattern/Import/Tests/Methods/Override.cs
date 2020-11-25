using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Methods
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
            => type.GetMethod(Support.MethodName)
                   .GetParameters()
                   .First(p => p.Name.Equals(DependencyName))
                   .ParameterType;

        #endregion


        // Due to a bug in v4 (https://github.com/unitycontainer/unity/blob/a370e3cd8c0f9aa5f505e896ef5225f42711d361/source/Unity/Src/ParameterOverride.cs#L42)
        // Overrides only worked for constructors and DependencyOverride(...)

        #region Not Supported in Unity v4

#if BEHAVIOR_V4
        public override void Implicit_With_MemberOverride(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
        public override void Implicit_With_ParameterType(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
        public override void Implicit_With_TargetType(string test, Type type, object @default, object defaultAttr, object registered, object named, object injected, object overridden, bool isResolveble) { }
        public override void Annotated_With_Optional(string test, Type type) { }
        public override void Annotated_With_Required(string test, Type type) { }
        public override void Injected_Annotated(string test, Type type) { }
        public override void Injected_Implicit(string test, Type type) { }
#endif

        #endregion
    }
}
