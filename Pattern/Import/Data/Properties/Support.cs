using System;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Properties
{
    public static class Support
    {
        private const string PropertyName = "Property";

        public static InjectionMember GetByNameMember(Type type, string name)
            => new InjectionProperty(PropertyName);

        public static InjectionMember GetByNameOptional(Type type, string name)
#if V4
            => new InjectionProperty(PropertyName, new OptionalParameter(type, name));
#elif V5
            => new InjectionProperty(PropertyName, true);
#else
            => new OptionalProperty(PropertyName);
#endif

        public static InjectionMember GetResolvedMember(Type type, string name)
            => new InjectionProperty(PropertyName, new ResolvedParameter(type, name));

        public static InjectionMember GetOptionalMember(Type type, string name)
            => new InjectionProperty(PropertyName, new OptionalParameter(type, name));

        public static InjectionMember GetOptionalOptional(Type type, string name)
#if V4
            => new InjectionProperty(PropertyName, new OptionalParameter(type, name));
#elif V5
            => new InjectionProperty(PropertyName, new OptionalParameter(type, name));
#else
            => new OptionalProperty(PropertyName, new OptionalParameter(type, name));
#endif

        public static InjectionMember GetGenericMember(Type _, string name)
            => new InjectionProperty(PropertyName, new GenericParameter("T", name));

        public static InjectionMember GetGenericOptional(Type type, string name)
            => new InjectionProperty(PropertyName, new OptionalGenericParameter("T", name));

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionProperty(PropertyName, argument);

        public static InjectionMember GetInjectionOptional(object argument)
#if V4
            => new InjectionProperty(PropertyName, argument);
#elif V5
            => new InjectionProperty(PropertyName, argument);
#else
            => new OptionalProperty(PropertyName, argument);
#endif
    }
}
