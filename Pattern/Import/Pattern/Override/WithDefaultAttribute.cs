using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Regression.Override
{
    public abstract partial class Pattern 
    {
        [DataTestMethod]
        [DynamicData(nameof(Implicit_WithDefaultValueAttribute_Data))]
        public virtual void Implicit_With_DefaultValueAttribute(string test, Type type)
        {
            var import = GetImportType(type);
            var value = GetOverrideValue(import);
            var @override = Override_MemberOverride_WithType(import, DependencyName, value);

            // Act
            var instance = Container.Resolve(type, null, @override) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.IsInstanceOfType(instance.Value, instance.Dependency);
            Assert.AreEqual(import, instance.Dependency);
            Assert.AreEqual(value, instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(Annotated_WithDefaultValueAttribute_Data))]
        public virtual void Annotated_WithDefaultValueAttribute(string test, Type type)
        {
            var import = GetImportType(type);
            var value = GetOverrideValue(import);
            var @override = Override_MemberOverride_WithType(import, DependencyName, value);

            // Act
            var instance = Container.Resolve(type, null, @override) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.IsInstanceOfType(instance.Value, instance.Dependency);
            Assert.AreEqual(import, instance.Dependency);
            Assert.AreEqual(value, instance.Value);
        }
    }
}
