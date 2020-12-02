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

            public static ResolverOverride GetMemberOverrideOnType(Type target, string name, object value)
                => new ParameterOverride(name, value).OnType(target);

            public static ResolverOverride GetMemberOverrideWithContract(Type type, string name, object value)
#if UNITY_V4
                => new ParameterOverride(name, value);
#else
                => new ParameterOverride(type, name, value);
#endif

            public static ResolverOverride GetMemberOverrideWithContractOnType(Type target, Type type, string name, object value)
#if UNITY_V4
                => new ParameterOverride(name, value).OnType(target);
#else
                => new ParameterOverride(type, name, value).OnType(target);
#endif

            #endregion
        }
    }
}
