using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Import
{
    /// <summary>
    /// Tests injecting dependencies with InjectionParameter
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionConstructor(new GenericParameter(...)), 
    ///                                new InjectionMethod("Method", new GenericParameter(...)) , 
    ///                                new InjectionField("Field", new GenericParameter(...)), 
    ///                                new InjectionProperty("Property", new GenericParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Fields

        protected Type _resolvedTestType;

        #endregion


        #region ()

        [TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void ResolvedGeneric_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                     object registered, object named, object injected, object overridden, 
                                                     object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType, type, 
                InjectionMember_Value(new GenericParameter(TDependency)), 
                registered);


        [TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void ResolvedGeneric_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                             object registered, object named, object injected, object overridden, 
                                                             object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed, type, 
                InjectionMember_Value(new GenericParameter(TDependency)), 
                registered);


        [TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void ResolvedGeneric_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected,
                                           object overridden, object @default)
        {
            var target = _resolvedTestType ??= GetTestType("ObjectTestType");

            Container.RegisterType(null, target, null, null, InjectionMember_Value(new OptionalGenericParameter(TDependency)));

            // Validate
#if BEHAVIOR_V5
            Assert.ThrowsException<ArgumentException>(() => Container.Resolve(target, null));
#else
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));
#endif
            RegisterTypes();    // Register missing types

            // Act
#if BEHAVIOR_V5
            Assert.ThrowsException<ArgumentException>(() => Container.Resolve(target, null));
#else
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));
#endif
        }

        #endregion


        #region Name

        [TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void ResolvedGeneric_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                      object registered, object named, object injected, object overridden, 
                                                      object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType, type, 
                InjectionMember_Value(new GenericParameter(TDependency, Name)), 
                named);


        [TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void ResolvedGeneric_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                              object registered, object named, object injected, object overridden, 
                                                              object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed, type, 
                InjectionMember_Value(new GenericParameter(TDependency, null)), 
                registered);

        #endregion


        #region Array

        [TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void ResolvedGeneric_ArrayNotation(string test, Type type, object defaultValue, object defaultAttr,
                                                           object registered, object named, object injected, object overridden,
                                                           object @default)
        {
            Container.RegisterInstance(type, "default",     defaultValue);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered);
            Container.RegisterInstance(type, "named",       named);
            Container.RegisterInstance(type, "injected ",   injected);
            Container.RegisterInstance(type, "overridden",  overridden);

            Assert_Array_Import(BaselineArrayType, type, 
                InjectionMember_Value(new GenericParameter(TDependency + "[]")),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }

        [TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void ResolvedGeneric_ParentnessNotation(string test, Type type, object defaultValue, object defaultAttr,
                                                                object registered, object named, object injected, object overridden, 
                                                                object @default)
        {
            Container.RegisterInstance(type, "default",     defaultValue);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered);
            Container.RegisterInstance(type, "named",       named);
            Container.RegisterInstance(type, "injected",    injected);
            Container.RegisterInstance(type, "overridden",  overridden);

            Assert_Array_Import(BaselineArrayType, type, 
                InjectionMember_Value(new GenericParameter(TDependency + "()")),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }

        #endregion


        #region Validation

        [TestMethod, TestProperty(PARAMETER, nameof(GenericParameter))]
        [ExpectedException(typeof(ArgumentNullException))]
        public virtual void ResolvedGeneric_NoName()
        {
            _ = new GenericParameter(null);
        }

        #endregion
    }
}
