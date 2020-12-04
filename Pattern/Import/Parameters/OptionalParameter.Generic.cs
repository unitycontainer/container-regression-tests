using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Import
{
    /// <summary>
    /// Tests injecting dependencies with InjectionParameter
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionConstructor(new OptionalGenericParameter(...)), 
    ///                                new InjectionMethod("Method", new OptionalGenericParameter(...)) , 
    ///                                new InjectionField("Field", new OptionalGenericParameter(...)), 
    ///                                new InjectionProperty("Property", new OptionalGenericParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Default
#if !UNITY_V4
        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OptionalGeneric_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestType, type, InjectionMember_Value(new OptionalGenericParameter(TDependency)), @default, registered);


        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OptionalGeneric_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestType, type, InjectionMember_Value(new OptionalGenericParameter(TDependency)), @default, registered);
#endif
        #endregion


        #region Name

        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OptionalGeneric_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestType, type, InjectionMember_Value(new OptionalGenericParameter(TDependency, Name)), @default, named);


        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OptionalGeneric_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestType, type, InjectionMember_Value(new OptionalGenericParameter(TDependency, (string)null)), @default, registered);

        #endregion
    }
}
