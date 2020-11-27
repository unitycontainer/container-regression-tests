using Microsoft.VisualStudio.TestTools.UnitTesting;
using Manager;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class ImportBase
    {
        protected void TestOptionalImport(Type definition, Type importType, object expected)
        {

            // Arrange
            var type = definition.MakeGenericType(importType);

            // Validate
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void TestOptionalImport(Type definition, Type importType, InjectionMember injected, object expected)
        {

            // Arrange
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, type, null, null, injected);

            // Validate
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

        protected void TestOptionalGeneric(Type definition, Type importType, InjectionMember injected, object expected)
        {
            // Arrange
            var type = definition.MakeGenericType(importType);

            Container.RegisterType(null, definition, null, null, injected);

            // Validate
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Default, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }
    }
}


