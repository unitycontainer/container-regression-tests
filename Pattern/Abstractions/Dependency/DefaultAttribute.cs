using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Dependency
{
    public abstract partial class Pattern
    {
        private const string v4 = "v4 does not support default value";

        // Defaults are not supported in Unity v4
        #region With Defaults

#if BEHAVIOR_V4
        [Ignore(v4)]
#endif
        [PatternTestMethod("Dependency with default Value"), TestCategory(CATEGORY_DEPENDENCY)]
        [DynamicData(nameof(WithDefaultValue_Data))]
        public virtual void Import_WithDefault_Value(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as DependencyBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Default, instance.Value);

            // Arrange
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as DependencyBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
#if !BEHAVIOR_V5
            Assert.AreEqual(Container.Resolve(instance.ImportType, null), instance.Value);
#endif
        }

#if BEHAVIOR_V4
        [Ignore(v4)]
#endif
        [PatternTestMethod("Dependency with DefaultValue attribute"), TestCategory(CATEGORY_DEPENDENCY)]
        [DynamicData(nameof(WithDefaultAttribute_Data))]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void Import_WithDefault_Attribute(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as DependencyBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Default, instance.Value);

            // Arrange
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as DependencyBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
#if !BEHAVIOR_V5

            Assert.AreEqual(Container.Resolve(instance.ImportType, null), instance.Value);
#endif
        }


#if BEHAVIOR_V4
        [Ignore(v4)]
#endif
        [PatternTestMethod("Dependency with default Value and Attribute"), TestCategory(CATEGORY_DEPENDENCY)]
        [DynamicData(nameof(WithDefaultAndAttribute_Data))]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void Import_WithDefault_ValueAndAttribute(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as DependencyBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Default, instance.Value);

            // Arrange
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null) as DependencyBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(Container.Resolve(instance.ImportType, null), instance.Value);
        }
        #endregion
    }
}
