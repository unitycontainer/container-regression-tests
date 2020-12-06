using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Import.Implicit
{
    public abstract partial class Pattern
    {
        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void OptionalGeneric_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                     object registered, object named, object injected, object overridden, object @default)
            => Assert_AlwaysSuccessful(BaselineTestNamed, type, 
                InjectionMember_Value(new OptionalGenericParameter(TDependency)),
                @default, registered);
    }
}
