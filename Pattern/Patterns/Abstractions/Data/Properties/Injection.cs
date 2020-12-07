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
            #region Injection

            public static InjectionMember GetInjectionDefault()
                => new InjectionProperty(PropertyName);

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionProperty(PropertyName, argument);

            public static InjectionMember GetInjectionContract(Type type, string name)
                => new InjectionProperty(PropertyName, type, name);


            public static InjectionMember GetInjectionDefaultOptional()
                => new OptionalProperty(PropertyName);

            public static InjectionMember GetInjectionValueOptional(object argument)
                => new OptionalProperty(PropertyName, argument);

            public static InjectionMember GetInjectionContractOptional(Type type, string name)
                => new OptionalProperty(PropertyName, type, name);

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(object value)
                => new PropertyOverride(PropertyName, value);

            public static ResolverOverride GetMemberOverrideByName(string name, object value)
                => new PropertyOverride(name, value);

            public static ResolverOverride GetMemberOverrideByType(Type type, object value)
                => throw new NotSupportedException();

            public static ResolverOverride GetMemberOverrideWithContract(Type _, object value)
                => throw new NotSupportedException();

            #endregion
        }
    }
}
