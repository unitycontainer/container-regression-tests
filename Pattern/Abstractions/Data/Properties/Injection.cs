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
        private static class Properties
        {
            #region Default

            public static InjectionMember GetInjectionDefault()
                => new InjectionProperty(PropertyName);

            #endregion


            #region Value

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionProperty(PropertyName, argument);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(object value)
                => new PropertyOverride(PropertyName, value);

            public static ResolverOverride GetMemberOverrideByName(string name, object value)
                => new PropertyOverride(name, value);

            public static ResolverOverride GetMemberOverrideWithContract(Type _, string name, object value)
                => new PropertyOverride(name, value);

            #endregion
        }
    }
}
