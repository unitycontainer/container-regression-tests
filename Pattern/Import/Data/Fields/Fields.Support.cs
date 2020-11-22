using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Fields
{
    public static class Support
    {
        private const string FieldName = "Field";

        public static InjectionMember GetByNameMember(Type type, string name)
            => new InjectionField(FieldName);

        public static InjectionMember GetByNameOptional(Type type, string name)
#if V5
            => new InjectionField(FieldName, true);
#else
            => new OptionalField(FieldName);
#endif

        public static InjectionMember GetResolvedMember(Type type, string name)
            => new InjectionField(FieldName, new ResolvedParameter(type, name));

        public static InjectionMember GetOptionalMember(Type type, string name)
            => new InjectionField(FieldName, new OptionalParameter(type, name));

        public static InjectionMember GetOptionalOptional(Type type, string name)
#if V5
            => new InjectionField(FieldName, new OptionalParameter(type, name));
#else
            => new OptionalField(FieldName, new OptionalParameter(type, name));
#endif

        public static InjectionMember GetGenericMember(Type _, string name)
            => new InjectionField(FieldName, new GenericParameter("T", name));

        public static InjectionMember GetGenericOptional(Type type, string name)
            => new InjectionField(FieldName, new OptionalGenericParameter("T", name));

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionField(FieldName, argument);

        public static InjectionMember GetInjectionOptional(object argument)
#if V5
            => new InjectionField(FieldName, argument);
#else
            => new OptionalField(FieldName, argument);
#endif
    }
}
