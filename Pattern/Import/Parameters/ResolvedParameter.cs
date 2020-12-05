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
    /// Container.RegisterType(target, new InjectionConstructor(new ResolvedParameter(...)), 
    ///                                new InjectionMethod("Method", new ResolvedParameter(...)) , 
    ///                                new InjectionField("Field", new ResolvedParameter(...)), 
    ///                                new InjectionProperty("Property", new ResolvedParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region ()
#if !UNITY_V4
        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Resolved_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter()), 
                registered);


        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Resolved_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter()), 
                named);
#endif
        #endregion


        #region Type

        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Resolved_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter(type)), 
                registered);


        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Resolved_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter(type)), 
                registered);

        #endregion


        #region Name

#if !UNITY_V4
        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Resolved_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter(Name)), 
                named);


        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Resolved_WithNullName(string test, Type type, object defaultValue, object defaultAttr,
                                                  object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter((string)null)), 
                registered);
#endif

        #endregion


        #region Contract

        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Resolved_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter(type, Name)), 
                named);


        [TestProperty(PARAMETER, nameof(ResolvedParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Resolved_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedParameter(type, null)), 
                registered);
        
        #endregion
    }
}
