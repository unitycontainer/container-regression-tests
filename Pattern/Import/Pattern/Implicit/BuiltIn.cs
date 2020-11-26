using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Implicit
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(ImportBase))]
        public virtual void BuiltIn_Interface(string test, Type type)
        {
            // Arrange
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
        }

        [DataTestMethod]
        [DynamicData(nameof(BuiltInTypes_Data), typeof(ImportBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void BuiltIn_Interface_Named(string test, Type type)
        {
            // Arrange
            // Act
            var instance = Container.Resolve(type, Name);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
        }
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Array(string test, Type type, object @default, object defaultAttr, object registered, 
                                  object named, object injected, object overridden, bool isResolveble)
            => TestArrayImport(ImplicitArrayType, type);

#if !BEHAVIOR_V4
        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Enumerable(string test, Type type, object @default, object defaultAttr, object registered, 
                                       object named, object injected, object overridden, bool isResolveble)
            => TestEnumerableImport(ImplicitImportType, type);
#endif

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Lazy(string test, Type type, object @default, object defaultAttr, object registered, 
                                 object named, object injected, object overridden, bool isResolveble)
            => TestLazyImport(ImplicitImportType, type, registered);

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Func(string test, Type type, object @default, object defaultAttr, object registered, 
                                 object named, object injected, object overridden, bool isResolveble)
            => TestFuncImport(ImplicitImportType, type, registered);
    }
}
