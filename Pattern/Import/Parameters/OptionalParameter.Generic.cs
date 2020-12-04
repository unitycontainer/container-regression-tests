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
    /// Container.RegisterType(target, new InjectionConstructor(new OptionalGenericParameter(...)), 
    ///                                new InjectionMethod("Method", new OptionalGenericParameter(...)) , 
    ///                                new InjectionField("Field", new OptionalGenericParameter(...)), 
    ///                                new InjectionProperty("Property", new OptionalGenericParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Fields

        protected Type _optionalTestType;

        #endregion


        #region ()

        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void OptionalGeneric_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestType, type, 
                InjectionMember_Value(new OptionalGenericParameter(TDependency)), 
                @default, registered);


        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void OptionalGeneric_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected,
                                           object overridden, object @default)
        {
            var target = _optionalTestType ??= GetTestType("ObjectTestType");

#if BEHAVIOR_V4 || BEHAVIOR_V5
            Assert.ThrowsException<InvalidOperationException>(()
                => Container.RegisterType(null, target, null, null, InjectionMember_Value(new OptionalGenericParameter(TDependency))));
#else
            // No validation during registration 
            Container.RegisterType(null, target, null, null, InjectionMember_Value(new OptionalGenericParameter(TDependency)));

            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));
            RegisterTypes();    // Register missing types

            // Act
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));
#endif
        }


        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void OptionalGeneric_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestNamed, type, 
                InjectionMember_Value(new OptionalGenericParameter(TDependency)),
#if BEHAVIOR_V4 || BEHAVIOR_V5
                @default, registered);
#else
                @default, named);
#endif

        #endregion


        #region Name

        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void OptionalGeneric_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestType, type, 
                InjectionMember_Value(new OptionalGenericParameter(TDependency, Name)), 
                @default, named);


        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void OptionalGeneric_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, object @default)
            => Asssert_AlwaysSuccessful(BaselineTestType, type, 
                InjectionMember_Value(new OptionalGenericParameter(TDependency, null)), 
                @default, registered);

        #endregion


        #region Array

        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void OptionalGeneric_ArrayNotation(string test, Type type, object defaultValue, object defaultAttr,
                                                           object registered, object named, object injected, object overridden,
                                                           object @default)
        {
            Container.RegisterInstance(type, "default", defaultValue);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered);
            Container.RegisterInstance(type, "named", named);
            Container.RegisterInstance(type, "injected ", injected);
            Container.RegisterInstance(type, "overridden", overridden);

            Assert_Array_Import(BaselineArrayType, type,
                InjectionMember_Value(new GenericParameter(TDependency + "[]")),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }

        [TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void OptionalGeneric_ParentnessNotation(string test, Type type, object defaultValue, object defaultAttr,
                                                                object registered, object named, object injected, object overridden,
                                                                object @default)
        {
            Container.RegisterInstance(type, "default", defaultValue);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered);
            Container.RegisterInstance(type, "named", named);
            Container.RegisterInstance(type, "injected", injected);
            Container.RegisterInstance(type, "overridden", overridden);

            Assert_Array_Import(BaselineArrayType, type,
                InjectionMember_Value(new GenericParameter(TDependency + "()")),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }

        #endregion


        #region Validation

        [TestMethod, TestProperty(PARAMETER, nameof(OptionalGenericParameter))]
        [ExpectedException(typeof(ArgumentNullException))]
        public virtual void OptionalGeneric_NoName()
        {
            _ = new OptionalGenericParameter(null);
        }

        #endregion
    }
}
