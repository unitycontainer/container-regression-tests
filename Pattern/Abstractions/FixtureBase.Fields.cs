using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        private static class Fields
        {
            private const string FieldName = "Field";

            #region By Name

            public static InjectionMember GetInjectionMember_ByName_Required(Type importType)
                => new InjectionField(FieldName);

            public static InjectionMember GetInjectionMember_ByName_Optional(Type importType)
    #if UNITY_V5
                => new InjectionField(FieldName, Unity.ResolutionOption.Optional);
    #else
                => new OptionalField(FieldName);
    #endif
            #endregion


            #region By Type

            public static InjectionMember GetInjectionMember_ByType_Required(Type importType)
                => new InjectionField(FieldName, importType);

            public static InjectionMember GetInjectionMember_ByType_Optional(Type importType)
    #if UNITY_V5
                => new InjectionField(FieldName, new OptionalParameter(importType));
    #else
                => new OptionalField(FieldName, importType);
    #endif
            #endregion


            #region Value

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionField(FieldName, argument);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(string name, object value)
                => new FieldOverride(name, value);

            public static ResolverOverride GetMemberOverrideWithType(Type _, string name, object value)
                => new FieldOverride(name, value);

            public static ResolverOverride GetMemberOverrideOnType(Type target, Type _, string name, object value)
                => new FieldOverride(name, value).OnType(target);

            #endregion
        }
    }
}
