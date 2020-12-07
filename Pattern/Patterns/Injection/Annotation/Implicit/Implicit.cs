﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Injection.Implicit
{
    public abstract partial class Pattern : Injection.Pattern
    {

        [TestCategory(CATEGORY_INJECT)]
        [ExpectedException(typeof(ResolutionFailedException))]
        [DataTestMethod, DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        public virtual void Throws_OnRefParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Ref`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }

        [TestCategory(CATEGORY_INJECT)]
        [ExpectedException(typeof(ResolutionFailedException))]
        [DataTestMethod, DynamicData(nameof(SupportedTypes_Data), typeof(FixtureBase))]
        public virtual void Throws_OnOutParameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Out`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }



        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Injection.Pattern))]
        public override void Inject_Named_Default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type),
                InjectionMember_Default(), registered);
    }
}