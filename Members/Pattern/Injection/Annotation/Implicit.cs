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
        const string ThrowsOnParameterConst = "Throws on {2} {3}";

        [PatternTestMethod(ThrowsOnParameterConst), TestCategory(CATEGORY_INJECT)]
        [ExpectedException(typeof(ResolutionFailedException))]
        [DynamicData(nameof(Unity_Recognized_Types_Data), typeof(PatternBase))]
        public virtual void Throws_On_Ref_Parameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Ref`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }




        [PatternTestMethod(ThrowsOnParameterConst), TestCategory(CATEGORY_INJECT)]
        [ExpectedException(typeof(ResolutionFailedException))]
        [DynamicData(nameof(Unity_Recognized_Types_Data), typeof(PatternBase))]
        public virtual void Throws_On_Out_Parameter(string test, Type type)
        {
            // Arrange
            var target = GetType("BaselineTestType_Out`1").MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null);
        }




#if !UNITY_V4
        [DataTestMethod, DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public override void Inject_Named_Default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
            => Assert_ThrowsWhenNotRegistered(
                BaselineTestNamed.MakeGenericType(type),
                InjectionMember_Default(), registered);
#endif
    }
}
