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
        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OptionalGenericParameter_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedGeneric(type, InjectionMember_Value(new OptionalGenericParameter(TDependency)), registered, @default);


        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void OptionalGenericParameter_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamedGeneric(type, InjectionMember_Value(new OptionalGenericParameter(TDependency)), registered, @default);
#endif
        #endregion


        #region Name

        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OptionalGenericParameter_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectedGeneric(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, Name)), named, @default);


        [TestCategory(Category_Parameter)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void OptionalGenericParameter_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Assert_InjectNamedGeneric(type, InjectionMember_Value(new OptionalGenericParameter(TDependency, (string)null)), registered, @default);

        #endregion
    }
}
