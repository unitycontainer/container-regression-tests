using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import
{
    public abstract partial class Pattern
    {
        #region Type

        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_ByType_Null(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type), registered);

        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_ByType_Named(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type), named);

        #endregion


        #region Inherited

        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Import_InInherited(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                CorrespondingTypeDefinition.MakeGenericType(type), registered);


        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Import_InInherited_Twice(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                CorrespondingTypeDefinition.MakeGenericType(type), registered);

        #endregion


        #region With Defaults
#if !UNITY_V4 // Defaults are not supported in Unity v4
#if BEHAVIOR_V4
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(WithDefaultValue_Data))]
        public virtual void Import_WithDefault_Value(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Default, instance.Value);

            // Arrange
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
#if !BEHAVIOR_V5
            Assert.AreEqual(Container.Resolve(instance.ImportType, null), instance.Value);
#endif
        }

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(WithDefaultAttribute_Data))]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void Import_WithDefault_Attribute(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Default, instance.Value);

            // Arrange
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
#if !BEHAVIOR_V5

            Assert.AreEqual(Container.Resolve(instance.ImportType, null), instance.Value);
#endif
        }


#if BEHAVIOR_V4
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(WithDefaultAndAttribute_Data))]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void Import_WithDefault_ValueAndAttribute(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Default, instance.Value);

            // Arrange
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as ImportBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
#if !BEHAVIOR_V5
            Assert.AreEqual(Container.Resolve(instance.ImportType, null), instance.Value);
#endif
        }
#endif
        #endregion
    }
}
