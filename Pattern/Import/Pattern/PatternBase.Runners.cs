using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
    public abstract partial class PatternBase
    {
        #region Fields

        protected Type TypeDefinition;

        #endregion


        #region Runners

        protected void TestRequiredImport(string @namespace, string testType, Type importType, InjectionMember injected, object expected)
        {
            var target = (TypeDefinition ??= GetType(@namespace, testType))
                .MakeGenericType(importType);

            Container.RegisterType(target, injected);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

        }

        protected void TestOptionalImport(string @namespace, string testType, Type importType, InjectionMember injected, object expected)
        {

            // Arrange
            var target = (TypeDefinition ??= GetType(@namespace, testType))
                .MakeGenericType(importType);

            Container.RegisterType(target, injected);

            // Validate
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Expected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void TestWithDefaultValue(string @namespace, string testType, Type importType, InjectionMember injected, object expected, object @default)
        {

            // Arrange
            var target = (TypeDefinition ??= GetType(@namespace, testType))
                .MakeGenericType(importType);

            Container.RegisterType(target, injected);

            // Validate
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(@default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        #endregion
    }
}


