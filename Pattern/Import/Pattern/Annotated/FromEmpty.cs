using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated
{
    public abstract partial class Pattern
    {
        #region Required

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_FromEmpty(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(RequiredImportType, type, registered);


        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Required_Named(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestRequiredImport(_requiredNamed, type, named);


        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Required_Resolvable(string test, Type type)
        {
            // Arrange
            var target = RequiredImportType.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(ResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Optional_Resolvable(string test, Type type)
        {
            // Arrange
            var target = OptionalImportType.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
        }

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Optional_FromEmpty(string test, Type type,
                                                         object @default, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         bool isResolveble)
            => TestOptionalImport(OptionalImportType, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(PatternBase))]
        public virtual void Optional_Named(string test, Type type,
                                                     object @default, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
            => TestOptionalImport(_optionalNamed, type, named);

        #endregion
    }
}
