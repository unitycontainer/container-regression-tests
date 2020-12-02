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

            #region Default

            public static InjectionMember GetInjectionDefault()
                => new InjectionField(FieldName);

            #endregion


            #region Value

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionField(FieldName, argument);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(string name, object value)
                => new FieldOverride(name, value);

            public static ResolverOverride GetMemberOverrideOnType(Type target, string name, object value)
                => new FieldOverride(name, value).OnType(target);

            public static ResolverOverride GetMemberOverrideWithContract(Type _, string name, object value)
                => new FieldOverride(name, value);

            public static ResolverOverride GetMemberOverrideWithContractOnType(Type target, Type _, string name, object value)
                => new FieldOverride(name, value).OnType(target);

            #endregion
        }
    }
}
