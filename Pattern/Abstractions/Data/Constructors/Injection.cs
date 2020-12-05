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

            public static ResolverOverride GetMemberOverride(object value)
                => new ParameterOverride(ParamName, value);

            public static ResolverOverride GetMemberOverrideByName(string name, object value)
                => new ParameterOverride(name, value);

            public static ResolverOverride GetMemberOverrideWithContract(Type type, string name, object value)
    #if UNITY_V4
                => new ParameterOverride(name, value);
    #else
                => new ParameterOverride(type, name, value);
    #endif

            #endregion
        }
    }
}
