using System;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Methods
{
    public static class Support
    {
        private const string MethodName = "Method";

        public static InjectionMember GetByNameMember(Type type, string name)
            => new InjectionMethod(MethodName);

        public static InjectionMember GetByNameOptional(Type type, string name)
            => new InjectionMethod(MethodName);

        public static InjectionMember GetResolvedMember(Type type, string name)
            => new InjectionMethod(MethodName, new ResolvedParameter(type, name));

        public static InjectionMember GetOptionalMember(Type type, string name)
            => new InjectionMethod(MethodName, new ResolvedParameter(type, name));

        public static InjectionMember GetOptionalOptional(Type type, string name)
            => new InjectionMethod(MethodName, new OptionalParameter(type, name));

        public static InjectionMember GetGenericMember(Type _, string name)
            => new InjectionMethod(MethodName, new GenericParameter("T", name));

        public static InjectionMember GetGenericOptional(Type type, string name)
            => new InjectionMethod(MethodName, new OptionalGenericParameter("T", name));

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionMethod(MethodName, argument);

        public static InjectionMember GetInjectionOptional(object argument)
            => new InjectionMethod(MethodName, argument);
    }
}
