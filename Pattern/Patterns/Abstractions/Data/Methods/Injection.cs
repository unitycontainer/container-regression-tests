﻿using System;
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
    public abstract partial class PatternBase
    {
        private static class Methods
        {
            #region Injection

            public static InjectionMember GetInjectionDefault()
                => new InjectionMethod(MethodName);

            public static InjectionMember GetInjectionValue(object argument)
                => new InjectionMethod(MethodName, argument);

            public static InjectionMember GetInjectionContract(Type type, string name)
                => new InjectionMethod(MethodName, new ResolvedParameter(type, name));

            #endregion


            #region Override

            public static ResolverOverride GetMemberOverride(object value)
                => new ParameterOverride(ParameterName, value);

            public static ResolverOverride GetMemberOverrideByName(string name, object value)
                => new ParameterOverride(name, value);

            public static ResolverOverride GetMemberOverrideByType(Type type, object value)
#if UNITY_V4
                => new ParameterOverride(ParameterName, value);
#else
                => new ParameterOverride(type, value);
#endif
            public static ResolverOverride GetMemberOverrideWithContract(Type type, object value)
#if UNITY_V4 || UNITY_V5
                => new ParameterOverride(ParameterName, value);
#else
                => new ParameterOverride(ParameterName, type, value);
#endif
            #endregion
        }
    }
}
