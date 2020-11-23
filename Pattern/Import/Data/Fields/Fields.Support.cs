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

        #region By Name

        public static InjectionMember GetInjectionMember_ByName_Required(Type importType)
            => new InjectionField(FieldName);

        public static InjectionMember GetInjectionMember_ByName_Optional(Type importType)
#if UNITY_V5
            => new InjectionField(FieldName, Unity.ResolutionOption.Optional);
#else
            => new OptionalField(FieldName);
#endif
        #endregion


        #region By Type

        public static InjectionMember GetInjectionMember_ByType_Required(Type importType)
            => new InjectionField(FieldName, importType);

        public static InjectionMember GetInjectionMember_ByType_Optional(Type importType)
#if UNITY_V5
            => new InjectionField(FieldName, new OptionalParameter(importType));
#else
            => new OptionalField(FieldName, importType);
#endif
        #endregion

        public static InjectionMember GetResolvedMember(Type importType, string contractName)
            => new InjectionField(FieldName, new ResolvedParameter(importType, contractName));

        public static InjectionMember GetOptionalMember(Type importType, string contractName)
            => new InjectionField(FieldName, new OptionalParameter(importType, contractName));

        public static InjectionMember GetOptionalOptional(Type importType, string contractName)
#if V5
            => new InjectionField(FieldName, new OptionalParameter(importType, contractName));
#else
            => new OptionalField(FieldName, new OptionalParameter(importType, contractName));
#endif

        public static InjectionMember GetGenericMember(Type _, string contractName)
            => new InjectionField(FieldName, new GenericParameter("T", contractName));

        public static InjectionMember GetGenericOptional(Type importType, string contractName)
            => new InjectionField(FieldName, new OptionalGenericParameter("T", contractName));

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
