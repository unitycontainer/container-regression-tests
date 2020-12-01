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
        private static class Constructors
        {
            #region Default

            public static InjectionMember GetInjectionDefault()
                => new InjectionConstructor();
            
            #endregion


            #region Value

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionConstructor(argument);

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
