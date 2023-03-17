using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Methods
{
    [TestClass]
    public partial class Injecting_Required : Injection.Required.Pattern
    {
        #region Properties
        protected override string DependencyName => "value";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => Pattern_Initialize(context.FullyQualifiedTestClassName);

        #endregion


        #region Special Cases

#if BEHAVIOR_V4
        // This only worked in constructor
        public override void Member_Injected_ByInjectionParameter(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void Member_Injected_ByParameterRecursive(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
        public override void Member_Injected_ByValue(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#endif

        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        [PatternTestMethod("Inject Named dependency by XxxMember()"), TestCategory(CATEGORY_INJECT)]
        public override void Inject_Named_Default(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default)
                    => Assert_Injection(BaselineTestNamed.MakeGenericType(type),
                                        InjectionMember_Default(), @default, named);

        #endregion
    }
}
