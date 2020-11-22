﻿using System;
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

        public static InjectionMember GetInjectionMember_ByName_Required(Type type)
            => new InjectionMethod(MethodName, new ResolvedParameter(type));

        public static InjectionMember GetInjectionMember_ByName_Optional(Type type)
            => new InjectionMethod(MethodName, new OptionalParameter(type));

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

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionMethod(MethodName, argument);

        public static InjectionMember GetInjectionOptional(object argument)
            => new InjectionMethod(MethodName, argument);
    }
}
