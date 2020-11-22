using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    /// <summary>
    /// Tests injecting dependencies by member name
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionMethod("Method") , 
    ///                                new InjectionField("Field"), 
    ///                                new InjectionProperty("Property"));
    /// </example>
    public abstract partial class InjectedPattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void Implicit_WithRequired_ByName(string test,       Type type, 
                                                         object @default,   object defaultAttr, 
                                                         object registered, object named, 
                                                         object injected,   object overridden, 
                                                         bool isResolveble)
        {
            // Arrange
            var target = (TypeDefinition ??= GetType("Implicit", "BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionMember_Required_ByName(type));

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }


        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void Implicit_WithOptional_ByName(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            PatternBaseType instance = null;
            // Arrange
            var target = (TypeDefinition ??= GetType("Implicit", "BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionMember_Optional_ByName(type));

            // Validate
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
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

        
        #region Required

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void Required_WithRequired_ByName(string test, Type type,
                                                         object @default,   object defaultAttr,
                                                         object registered, object named,
                                                         object injected,   object overridden,
                                                         bool isResolveble)
        {
            // Arrange
            var target = (TypeDefinition ??= GetType("Annotated", "Required.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionMember_Required_ByName(type));

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }


        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void Required_WithOptional_ByName(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            PatternBaseType instance = null;
            
            // Arrange
            var target = (TypeDefinition ??= GetType("Annotated", "Required.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionMember_Optional_ByName(type));

            // Validate
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
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


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(RequiredImport_Data), typeof(PatternBase))]
        public virtual void Optional_WithRequired_ByName(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            // Arrange
            PatternBaseType instance = null;
            var target = (TypeDefinition ??= GetType("Annotated", "Optional.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionMember_Required_ByName(type));

            // Unity v4 did not evaluate annotations on the dependency
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(OptionalImport_Data), typeof(PatternBase))]
        public virtual void Optional_WithOptional_ByName(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
        {
            PatternBaseType instance = null;
            // Arrange
            var target = (TypeDefinition ??= GetType("Annotated", "Optional.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, InjectionMember_Optional_ByName(type));

            // Validate
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
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
