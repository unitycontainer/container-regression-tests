using System;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Constructors
{
    public static class Support
    {
        public static InjectionMember GetByNameMember(Type type, string name)
            => throw new NotSupportedException();

        public static InjectionMember GetByNameOptional(Type type, string name)
            => throw new NotSupportedException();

        public static InjectionMember GetResolvedMember(Type type, string name)
            => new InjectionConstructor(new ResolvedParameter(type, name));

        public static InjectionMember GetOptionalMember(Type type, string name)
            => new InjectionConstructor(new OptionalParameter(type, name));

        public static InjectionMember GetOptionalOptional(Type type, string name)
            => new InjectionConstructor(new OptionalParameter(type, name));

        public static InjectionMember GetGenericMember(Type _, string name)
            => new InjectionConstructor(new GenericParameter("T", name));

        public static InjectionMember GetGenericOptional(Type type, string name)
            => new InjectionConstructor(new OptionalGenericParameter("T", name));

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionConstructor(argument);

        public static InjectionMember GetInjectionOptional(object argument)
            => new InjectionConstructor(argument);
    }
}
