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
            private const string PropertyName = "Property";

            #region Default

            public static InjectionMember GetInjectionDefault()
                => new InjectionProperty(PropertyName);

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
