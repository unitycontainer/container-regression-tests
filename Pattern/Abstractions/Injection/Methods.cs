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
        private static class Methods
        {
            public const string MethodName = "Method";

            #region By Name

            public static InjectionMember GetInjectionMember_ByName_Required(Type importType)
#if UNITY_V4
                => new InjectionMethod(MethodName, new ResolvedParameter(importType));
#else
                => new InjectionMethod(MethodName, new ResolvedParameter());
#endif

            public static InjectionMember GetInjectionMember_ByName_Optional(Type importType)
#if UNITY_V4
                => new InjectionMethod(MethodName, new OptionalParameter(importType));
#else
                => new InjectionMethod(MethodName, new OptionalParameter());
#endif
            #endregion


            #region By Type

            public static InjectionMember GetInjectionMember_ByType_Required(Type importType)
                => new InjectionMethod(MethodName, new ResolvedParameter(importType));

            public static InjectionMember GetInjectionMember_ByType_Optional(Type importType)
                => new InjectionMethod(MethodName, new OptionalParameter(importType));

            #endregion


            #region Default

            public static InjectionMember GetInjectionDefault()
                => new InjectionMethod(MethodName);

            #endregion


            #region Value

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionMethod(MethodName, argument);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(string name, object value)
                => new ParameterOverride(name, value);

            public static ResolverOverride GetMemberOverrideWithType(Type type, string name, object value)
#if UNITY_V4
                => new ParameterOverride(name, value);
#else
                => new ParameterOverride(type, name, value);
#endif

            public static ResolverOverride GetMemberOverrideOnType(Type target, Type type, string name, object value)
#if UNITY_V4
                => new ParameterOverride(name, value).OnType(target);
#else
                => new ParameterOverride(type, name, value).OnType(target);
#endif

            #endregion
        }
    }
}
