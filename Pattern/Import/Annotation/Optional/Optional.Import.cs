using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Optional
{
    public abstract partial class Pattern
    {

        #region Type

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Import_ByType_Null(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type), 
                @default, registered);

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Import_ByType_Named(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_AlwaysSuccessful(BaselineTestNamed.MakeGenericType(type), 
                @default, named);

        #endregion


        #region Inherited

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Import_InInherited(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_AlwaysSuccessful(CorrespondingTypeDefinition.MakeGenericType(type), 
                @default, registered);


        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Import_InInherited_Twice(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_AlwaysSuccessful(CorrespondingTypeDefinition.MakeGenericType(type), 
                @default, registered);

        #endregion
    }
}
