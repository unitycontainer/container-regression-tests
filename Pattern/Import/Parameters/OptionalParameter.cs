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
    /// Container.RegisterType(target, new InjectionConstructor(new OptionalParameter(...)), 
    ///                                new InjectionMethod("Method", new OptionalParameter(...)) , 
    ///                                new InjectionField("Field", new OptionalParameter(...)), 
    ///                                new InjectionProperty("Property", new OptionalParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region ()
#if !UNITY_V4
        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Optional_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new OptionalParameter()), 
                @default, registered);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Optional_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestNamed.MakeGenericType(type),
                InjectionMember_Value(new OptionalParameter()), 
                @default, named);
#endif
        #endregion


        #region Type

        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void Optional_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new OptionalParameter(type)), 
                @default, registered);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void Optional_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new OptionalParameter(type)), 
                @default, registered);

        #endregion


        #region Name

#if !UNITY_V4
        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void Optional_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new OptionalParameter(Name)), 
                @default, named);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void Optional_WithNullName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new OptionalParameter((string)null)), 
                @default, registered);
#endif

        #endregion


        #region Contract

        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void Optional_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new OptionalParameter(type, Name)), 
                @default, named);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void Optional_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new OptionalParameter(type, null)), 
                @default, registered);
        
        #endregion
    }
}
