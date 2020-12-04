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
        #region Default
#if !UNITY_V4
        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Optional_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new OptionalParameter()), registered, @default);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Optional_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestNamed.MakeGenericType(type),
                InjectionMember_Value(new OptionalParameter()), named, @default);
#endif
        #endregion


        #region Type

        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Optional_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new OptionalParameter(type)), registered, @default);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Optional_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new OptionalParameter(type)), registered, @default);

        #endregion


        #region Name

#if !UNITY_V4
        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Optional_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new OptionalParameter(Name)), named, @default);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Optional_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new OptionalParameter((string)null)), registered, @default);
#endif

        #endregion


        #region Contract

        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Optional_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new OptionalParameter(type, Name)), named, @default);


        [TestProperty(PARAMETER, nameof(OptionalParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Optional_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_Injected(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new OptionalParameter(type, null)), registered, @default);
        
        #endregion
    }
}
