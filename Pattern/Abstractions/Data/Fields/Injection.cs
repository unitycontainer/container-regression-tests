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
            #region Default

            public static InjectionMember GetInjectionDefault()
                => new InjectionField(FieldName);

            #endregion


            #region Value

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionField(FieldName, argument);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(object value)
                => new FieldOverride(FieldName, value);

            public static ResolverOverride GetMemberOverrideByName(string name, object value)
                => new FieldOverride(name, value);

            public static ResolverOverride GetMemberOverrideWithContract(Type _, string name, object value)
                => new FieldOverride(name, value);

            #endregion
        }
    }
}
