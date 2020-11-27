using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Manager
{
    public abstract partial class FixtureBase
    {
        private static class Properties
        {
            private const string PropertyName = "Property";

            #region By Name

            public static InjectionMember GetInjectionMember_ByName_Required(Type _)
                => new InjectionProperty(PropertyName);

            public static InjectionMember GetInjectionMember_ByName_Optional(Type importType)
    #if UNITY_V4
                => new InjectionProperty(PropertyName, new OptionalParameter(importType));
    #elif UNITY_V5
                => new InjectionProperty(PropertyName, Unity.ResolutionOption.Optional);
    #else
                => new OptionalProperty(PropertyName);
    #endif
            #endregion


            #region By Type

            public static InjectionMember GetInjectionMember_ByType_Required(Type importType)
                => new InjectionProperty(PropertyName, importType);

            public static InjectionMember GetInjectionMember_ByType_Optional(Type importType)
    #if UNITY_V4 || UNITY_V5
                => new InjectionProperty(PropertyName, new OptionalParameter(importType));
    #else
                => new OptionalProperty(PropertyName, importType);
    #endif
            #endregion


            #region Value

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionProperty(PropertyName, argument);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(string name, object value)
                => new PropertyOverride(name, value);

            public static ResolverOverride GetMemberOverrideWithType(Type _, string name, object value)
                => new PropertyOverride(name, value);

            public static ResolverOverride GetMemberOverrideOnType(Type target, Type type, string name, object value)
                => new PropertyOverride(name, value).OnType(target);

            #endregion
        }
    }
}
