using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Properties
{
    public static class Support
    {
        private const string PropertyName = "Property";

        public static InjectionMember GetInjectionMember_ByName_Required(Type _)
            => new InjectionProperty(PropertyName);

        public static InjectionMember GetInjectionMember_ByName_Optional(Type importType)
#if UNITY_V4
            => new InjectionProperty(PropertyName, new OptionalParameter(importType));
#elif UNITY_V5
            => new InjectionProperty(PropertyName, Unity.ResolutionOption.Optional);
#else
            => new OptionalProperty(PropertyName);
#endif


        public static InjectionMember GetInjectionMember_ByType_Required(Type importType)
            => new InjectionProperty(PropertyName, importType);

        public static InjectionMember GetInjectionMember_ByType_Optional(Type importType)
#if UNITY_V4
            => new InjectionProperty(PropertyName, new OptionalParameter(importType));
#elif UNITY_V5
            => new InjectionProperty(PropertyName, importType, Unity.ResolutionOption.Optional);
#else
            => new OptionalProperty(PropertyName, importType);
#endif


        public static InjectionMember GetResolvedMember(Type importType, string contractName)
            => new InjectionProperty(PropertyName, new ResolvedParameter(importType, contractName));

        public static InjectionMember GetOptionalMember(Type importType, string contractName)
            => new InjectionProperty(PropertyName, new OptionalParameter(importType, contractName));

        public static InjectionMember GetOptionalOptional(Type importType, string contractName)
#if UNITY_V4
            => new InjectionProperty(PropertyName, new OptionalParameter(importType, contractName));
#elif UNITY_V5
            => new InjectionProperty(PropertyName, new OptionalParameter(importType, contractName));
#else
            => new OptionalProperty(PropertyName, new OptionalParameter(importType, contractName));
#endif

        public static InjectionMember GetGenericMember(Type _, string contractName)
            => new InjectionProperty(PropertyName, new GenericParameter("T", contractName));

        public static InjectionMember GetGenericOptional(Type importType, string contractName)
            => new InjectionProperty(PropertyName, new OptionalGenericParameter("T", contractName));

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionProperty(PropertyName, argument);

        public static InjectionMember GetInjectionOptional(object argument)
#if UNITY_V4
            => new InjectionProperty(PropertyName, argument);
#elif UNITY_V5
            => new InjectionProperty(PropertyName, argument);
#else
            => new OptionalProperty(PropertyName, argument);
#endif
    }
}
