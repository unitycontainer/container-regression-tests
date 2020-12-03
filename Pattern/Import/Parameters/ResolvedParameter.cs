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
        #region Default
#if !UNITY_V4
        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter()), registered);


        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter()), named);
#endif
        #endregion


        #region Type

        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter(type)), registered);


        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_WithType_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter(type)), registered);

        #endregion


        #region Name

#if !UNITY_V4
        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter(Name)), named);


        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter((string)null)), registered);
#endif

        #endregion


        #region Contract

        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter(type, Name)), named);


        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedParameter_WithContract_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new ResolvedParameter(type, null)), registered);
        
        #endregion
    }
}
