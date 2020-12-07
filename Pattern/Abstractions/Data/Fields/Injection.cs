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
            #region Injection

            public static InjectionMember GetInjectionDefault()
                => new InjectionField(FieldName);

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionField(FieldName, argument);

            public static InjectionMember GetInjectionContract(Type type, string name)
                => new InjectionField(FieldName, type, name);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(object value)
                => new FieldOverride(FieldName, value);

            public static ResolverOverride GetMemberOverrideByName(string name, object value)
                => new FieldOverride(name, value);

            public static ResolverOverride GetMemberOverrideByType(Type type, object value)
                => throw new NotSupportedException();

            public static ResolverOverride GetMemberOverrideWithContract(Type _, object value)
                => throw new NotSupportedException();

            #endregion
        }
    }
}
