using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Constructors
{
    public static class Support
    {
        public static InjectionMember GetInjectionMember_ByName_Required(Type type)
            => new InjectionConstructor(new ResolvedParameter(type));

        public static InjectionMember GetInjectionMember_ByName_Optional(Type type)
            => new InjectionConstructor(new OptionalParameter(type));

        public static InjectionMember GetResolvedMember(Type importType, string contractName)
            => new InjectionConstructor(new ResolvedParameter(importType, contractName));

        public static InjectionMember GetOptionalMember(Type importType, string contractName)
            => new InjectionConstructor(new OptionalParameter(importType, contractName));

        public static InjectionMember GetOptionalOptional(Type importType, string contractName)
            => new InjectionConstructor(new OptionalParameter(importType, contractName));

        public static InjectionMember GetGenericMember(Type _, string contractName)
            => new InjectionConstructor(new GenericParameter("T", contractName));

        public static InjectionMember GetGenericOptional(Type importType, string contractName)
            => new InjectionConstructor(new OptionalGenericParameter("T", contractName));

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionConstructor(argument);

        public static InjectionMember GetInjectionOptional(object argument)
            => new InjectionConstructor(argument);
    }
}
