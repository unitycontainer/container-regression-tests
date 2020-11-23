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
        #region By Name

        public static InjectionMember GetInjectionMember_ByName_Required(Type importType)
#if UNITY_V4 || UNITY_V5
            => new InjectionConstructor(new ResolvedParameter(importType));
#else
            => new InjectionConstructor(new ResolvedParameter());
#endif

        public static InjectionMember GetInjectionMember_ByName_Optional(Type importType)
#if UNITY_V4 || UNITY_V5
            => new InjectionConstructor(new OptionalParameter(importType));
#else
            => new InjectionConstructor(new OptionalParameter());
#endif
        #endregion


        #region By Type

        public static InjectionMember GetInjectionMember_ByType_Required(Type importType)
            => new InjectionConstructor(new ResolvedParameter(importType));

        public static InjectionMember GetInjectionMember_ByType_Optional(Type importType)
            => new InjectionConstructor(new OptionalParameter(importType));

        #endregion


        #region Value

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionConstructor(argument);

        #endregion

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

        public static InjectionMember GetInjectionOptional(object argument)
            => new InjectionConstructor(argument);
    }
}
