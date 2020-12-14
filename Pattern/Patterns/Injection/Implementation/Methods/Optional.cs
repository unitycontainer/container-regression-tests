﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Methods
{
    [TestClass]
    public partial class Injecting_Optional : Injection.Optional.Pattern
    {
        #region Properties
        protected override string DependencyName => "value";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Special Cases

#if !UNITY_V4

        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public override void Inject_Default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type),
                InjectionMember_Default(), @default, registered);


        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public override void Inject_Named_Default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestNamed.MakeGenericType(type),
                InjectionMember_Default(), @default, named);
#endif

        #endregion
    }
}
