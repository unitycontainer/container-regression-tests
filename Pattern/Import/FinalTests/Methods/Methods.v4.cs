using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Methods
{
    public partial class Implicit
    {
        public override void Member_ByValue(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#if !UNITY_V4
        public override void Member_ByInjectionMember(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#endif

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Member_ByResolvedNamed(string test, Type type, object defaultValue,
                                                     object defaultAttr, object registered, object named,
                                                     object injected, object overridden, object @default)
        {
            Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type),
                MemberOverride(new ResolvedParameter(type, Name)),
                registered);
        }
    }

    public partial class Optional
    {
        public override void Member_ByValue(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#if !UNITY_V4
        public override void Member_ByInjectionMember(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#endif

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Member_ByResolvedNamed(string test, Type type, object defaultValue,
                                                     object defaultAttr, object registered, object named,
                                                     object injected, object overridden, object @default)
        {
            Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type),
                MemberOverride(new ResolvedParameter(type, Name)),
                registered);
        }
    }

    public partial class Required
    {
        public override void Member_ByValue(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#if !UNITY_V4
        public override void Member_ByInjectionMember(string test, Type type, object defaultValue, object defaultAttr, object registered, object named, object injected, object overridden, object @default) { }
#endif

        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Import.Pattern))]
        public override void Member_ByResolvedNamed(string test, Type type, object defaultValue,
                                                     object defaultAttr, object registered, object named,
                                                     object injected, object overridden, object @default)
        {
            Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type),
                MemberOverride(new ResolvedParameter(type, Name)),
                registered);
        }
    }
}
