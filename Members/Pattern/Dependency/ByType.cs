﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;


namespace Dependency
{
    public abstract partial class Pattern
    {
        #region Constants

        private const string XX_FROM_COMPUTER = "{0} dependency from container";

        #endregion


        #region Type

        [PatternTestMethod(XX_FROM_COMPUTER), TestCategory(CATEGORY_DEPENDENCY)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Unnamed_ByType(string test, Type type,
                                           object defaultValue, object defaultAttr,
                                           object registered, object named,
                                           object injected, object overridden,
                                           object @default)

            => Assert_ThrowsWhenNotRegistered(BaselineTestType.MakeGenericType(type), registered);




        [PatternTestMethod(XX_FROM_COMPUTER), TestCategory(CATEGORY_DEPENDENCY)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Named_ByType(string test, Type type,
                                         object defaultValue, object defaultAttr,
                                         object registered, object named,
                                         object injected, object overridden,
                                         object @default)

            => Assert_ThrowsWhenNotRegistered(BaselineTestNamed.MakeGenericType(type), named);

        #endregion


        #region Inherited

        [DataTestMethod, TestCategory(CATEGORY_DEPENDENCY)]
        [DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public virtual void InInherited_Type(string test, Type type,
                                             object defaultValue, object defaultAttr,
                                             object registered, object named,
                                             object injected, object overridden,
                                             object @default)

            => Assert_ThrowsWhenNotRegistered(CorrespondingTypeDefinition.MakeGenericType(type), registered);





        [DataTestMethod, TestCategory(CATEGORY_DEPENDENCY)]
        [DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public virtual void Twice_InInherited_Type(string test, Type type,
                                                   object defaultValue, object defaultAttr,
                                                   object registered, object named,
                                                   object injected, object overridden,
                                                   object @default)

            => Assert_ThrowsWhenNotRegistered(CorrespondingTypeDefinition.MakeGenericType(type), registered);

        #endregion
    }
}
