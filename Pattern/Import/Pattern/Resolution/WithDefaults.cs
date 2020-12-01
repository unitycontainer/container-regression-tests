using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Import
{
    public abstract partial class Pattern
    {
#if BEHAVIOR_V4
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [DataTestMethod, DynamicData(nameof(WithDefaultValue_Data))]
        public virtual void WithDefault_Value(string test, Type type)
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
        [DataTestMethod, DynamicData(nameof(WithDefaultAttribute_Data))]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void WithDefault_Attribute(string test, Type type)
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
        [DataTestMethod, DynamicData(nameof(WithDefaultAndAttribute_Data))]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void WithDefault_ValueAndAttribute(string test, Type type)
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


        #region Test Data

        public static IEnumerable<object[]> WithDefaultValue_Data
        {
            get
            {
                var types = FromNamespace("WithDefault").ToArray();

                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummyImport) };
            }
        }

        public static IEnumerable<object[]> WithDefaultAttribute_Data
        {
            get
            {
                var types = FromNamespace("WithDefaultAttribute").ToArray();

                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummyImport) };
            }
        }

        public static IEnumerable<object[]> WithDefaultAndAttribute_Data
        {
            get
            {
                var types = FromNamespace("WithDefaultAndAttribute").ToArray();

                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummyImport) };
            }
        }

        #endregion
    }
}

