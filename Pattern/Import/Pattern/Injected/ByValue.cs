using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class InjectedPattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Implicit_WithValue(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            PatternBaseType instance = null;

            // Arrange
            var target = (TypeDefinition ??= GetType("Implicit", "BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionValue(injected));

            // Validate
            instance = Container.Resolve(target, null) as PatternBaseType;

            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Implicit_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
        {
            PatternBaseType instance = null;

            // Arrange
            var target = (TypeDefinition ??= GetType("Implicit", "BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionValue(InjectionMember_Required_ByType(type)));

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Required_WithValue(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            PatternBaseType instance = null;

            // Arrange
            var target = (TypeDefinition ??= GetType("Annotated", "Required.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionValue(injected));

            // Validate
            instance = Container.Resolve(target, null) as PatternBaseType;

            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Required_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
        {
            PatternBaseType instance = null;

            // Arrange
            var target = (TypeDefinition ??= GetType("Annotated", "Required.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionValue(InjectionMember_Required_ByType(type)));

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Optional_WithValue(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            PatternBaseType instance = null;

            // Arrange
            var target = (TypeDefinition ??= GetType("Annotated", "Optional.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionValue(injected));

            // Validate
            instance = Container.Resolve(target, null) as PatternBaseType;

            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void ByValue_Optional_WithResolver(string test, Type type,
                                                          object @default, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          bool isResolveble)
        {
            PatternBaseType instance = null;

            // Arrange
            var target = (TypeDefinition ??= GetType("Annotated", "Optional.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionValue(InjectionMember_Optional_ByType(type)));

            // Validate
            instance = Container.Resolve(target, null) as PatternBaseType;

            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Expected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }

        #endregion
    }
}
