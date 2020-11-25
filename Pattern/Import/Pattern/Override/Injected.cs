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
        [DynamicData(nameof(Implicit_Data), typeof(PatternBase))]
        public virtual void Injected_Implicit(string test, Type type)
        {
            // Arrange
            var import = GetImportType(type);
            var injected = GetInjectedValue(import);
            var @override = GetOverrideValue(import);
            
            Container.RegisterType(null, type, null, null, InjectionMember_Value(injected));

            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.IsInstanceOfType(instance.Value, instance.ImportType);
            Assert.AreEqual(import, instance.ImportType);
            Assert.AreEqual(instance.Injected, instance.Value);

            // Act
            instance = Container.Resolve(type, null, Override_MemberOverride_WithType(import, DependencyName, @override)) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.IsInstanceOfType(instance.Value, instance.ImportType);
            Assert.AreEqual(import, instance.ImportType);
            Assert.AreEqual(instance.Override, instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(Annotated_Optional_Data), typeof(PatternBase))]
        [DynamicData(nameof(Annotated_Required_Data), typeof(PatternBase))]
        public virtual void Injected_Annotated(string test, Type type)
        {
            // Arrange
            var import = GetImportType(type);
            var injected = GetInjectedValue(import);
            var @override = GetOverrideValue(import);
            Container.RegisterType(null, type, null, null, InjectionMember_Value(injected));

            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.IsInstanceOfType(instance.Value, instance.ImportType);
            Assert.AreEqual(import, instance.ImportType);
            Assert.AreEqual(injected, instance.Value);

            // Act
            instance = Container.Resolve(type, null, Override_MemberOverride_WithType(import, DependencyName, @override)) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.IsInstanceOfType(instance.Value, instance.ImportType);
            Assert.AreEqual(import, instance.ImportType);
            Assert.AreEqual(@override, instance.Value);
        }
    }
}
