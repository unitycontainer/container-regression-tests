using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unity.Injection;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class Pattern
    {
        [TestProperty(OVERRIDE, MEMBER_OVERRIDE)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Member_ByValue(string test, Type type, object defaultValue,
                                           object defaultAttr, object registered, object named,
                                           object injected, object overridden, object @default)
        {
            Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                MemberOverride(overridden), overridden);
        }

        [TestProperty(OVERRIDE, MEMBER_OVERRIDE)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Member_ByInjectionMember(string test, Type type, object defaultValue,
                                                     object defaultAttr, object registered, object named,
                                                     object injected, object overridden, object @default)
        {
            Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                MemberOverride(new InjectionParameter(injected)), injected);
        }
    }
}
