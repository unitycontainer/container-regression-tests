using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Methods
{
    public static class Support
    {
        private const string MethodName = "Method";

        #region By Name

        public static InjectionMember GetInjectionMember_ByName_Required(Type importType)
#if UNITY_V4
            => new InjectionMethod(MethodName, new ResolvedParameter(importType));
#else
            => new InjectionMethod(MethodName, new ResolvedParameter());
#endif

        public static InjectionMember GetInjectionMember_ByName_Optional(Type importType)
#if UNITY_V4
            => new InjectionMethod(MethodName, new OptionalParameter(importType));
#else
            => new InjectionMethod(MethodName, new OptionalParameter());
#endif
        #endregion


        #region By Type

        public static InjectionMember GetInjectionMember_ByType_Required(Type importType)
            => new InjectionMethod(MethodName, new ResolvedParameter(importType));

        public static InjectionMember GetInjectionMember_ByType_Optional(Type importType)
            => new InjectionMethod(MethodName, new OptionalParameter(importType));

        #endregion


        #region Value

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionMethod(MethodName, argument);

        #endregion

        public static InjectionMember GetResolvedMember(Type importType, string contractName)
            => new InjectionMethod(MethodName, new ResolvedParameter(importType, contractName));

        public static InjectionMember GetOptionalMember(Type importType, string contractName)
            => new InjectionMethod(MethodName, new ResolvedParameter(importType, contractName));

        public static InjectionMember GetOptionalOptional(Type importType, string contractName)
            => new InjectionMethod(MethodName, new OptionalParameter(importType, contractName));

        public static InjectionMember GetGenericMember(Type _, string contractName)
            => new InjectionMethod(MethodName, new GenericParameter("T", contractName));

        public static InjectionMember GetGenericOptional(Type importType, string contractName)
            => new InjectionMethod(MethodName, new OptionalGenericParameter("T", contractName));

        public static InjectionMember GetInjectionOptional(object argument)
            => new InjectionMethod(MethodName, argument);
    }
}
