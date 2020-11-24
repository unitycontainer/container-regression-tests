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
        [DynamicData(nameof(Annotated_Required_Data), typeof(PatternBase))]
        public virtual void Annotated_With_Required(string test, Type type)
        {
            // Arrange
            var import = GetImportType(type);
            var @override = GetOverrideValue(import);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(type, null));

            // Act
            var instance = Container.Resolve(type, null, Override_MemberOverride_WithType(import, DependencyName, @override)) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.IsInstanceOfType(instance.Value, instance.ImportType);
            Assert.AreEqual(import, instance.ImportType);
            Assert.AreEqual(@override, instance.Value);
        }


        [DataTestMethod]
        [DynamicData(nameof(Annotated_Optional_Data), typeof(PatternBase))]
        public virtual void Annotated_With_Optional(string test, Type type)
        {
            // Arrange
            var import = GetImportType(type);
            var @override = GetOverrideValue(import);

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(import, instance.ImportType);
            Assert.AreEqual(instance.Default, instance.Value);

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
