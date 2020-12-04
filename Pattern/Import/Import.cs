using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import
{
    public abstract partial class Pattern
    {

        #region Type

        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_ByType_Null(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type), registered);

        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_ByType_Named(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type), named);

        #endregion


        #region Inherited

        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Import_InInherited(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                CorrespondingTypeDefinition.MakeGenericType(type), registered);


        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Import_InInherited_Twice(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                CorrespondingTypeDefinition.MakeGenericType(type), registered);

        #endregion
    }
}
