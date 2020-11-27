using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Annotated
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(ImportBase))]
        public virtual void Required_BuiltIn_Interface(string test, Type type)
        {
            // Arrange
            var target = RequiredImportType.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsInstanceOfType(instance.Value, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(ImportBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void Required_BuiltIn_Named(string test, Type type)
        {
            // Arrange
            var target = _requiredNamed.MakeGenericType(type);

            // Act
            _ = Container.Resolve(target, null) as PatternBaseType;
        }

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Required_Array(string test, Type type, object @default, object defaultAttr,
                                            object registered, object named, object injected, object overridden, bool isResolveble)
            => TestArrayImport(RequiredArrayType, type);

#if !BEHAVIOR_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Required_Enumerable(string test, Type type, object @default, object defaultAttr, object registered, 
                                                object named, object injected, object overridden, bool isResolveble)
            => TestEnumerableImport(RequiredImportType, type);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Resolving_Lazy(string test, Type type, object @default, object defaultAttr, object registered, 
                                           object named, object injected, object overridden, bool isResolveble)
            => TestLazyImport(RequiredImportType, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Required_Func(string test, Type type, object @default, object defaultAttr, object registered, 
                                          object named, object injected, object overridden, bool isResolveble)
            => TestFuncImport(RequiredImportType, type, registered);



        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(ImportBase))]
        public virtual void Optional_BuiltIn_Interface(string test, Type type)
        {
            // Arrange
            var target = OptionalImportType.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsInstanceOfType(instance.Value, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(ImportBase))]
        public virtual void Optional_BuiltIn_Named(string test, Type type)
        {
            // Arrange
            var target = _optionalNamed.MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsNull(instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Optional_Array(string test, Type type,
                                            object @default, object defaultAttr,
                                            object registered, object named,
                                            object injected, object overridden,
                                            bool isResolveble)
            => TestArrayImport(OptionalArrayType, type);

#if !BEHAVIOR_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Optional_Enumerable(string test, Type type,
                                            object @default, object defaultAttr,
                                            object registered, object named,
                                            object injected, object overridden,
                                            bool isResolveble)
            => TestEnumerableImport(OptionalImportType, type);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Optional_Lazy(string test, Type type,
                                            object @default, object defaultAttr,
                                            object registered, object named,
                                            object injected, object overridden,
                                            bool isResolveble)
            => TestLazyImport(OptionalImportType, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Optional_Func(string test, Type type,
                                            object @default, object defaultAttr,
                                            object registered, object named,
                                            object injected, object overridden,
                                            bool isResolveble)
            => TestFuncImport(OptionalImportType, type, registered);
    }
}
