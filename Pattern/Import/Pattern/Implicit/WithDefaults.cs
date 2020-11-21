using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Implicit
{
    public abstract partial class Pattern
    {
#if BEHAVIOR_V4
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [DynamicData(nameof(WithDefaultValue_Data))]
        [DataTestMethod]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void WithDefaultValue(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Expected, instance.Value);
        }


#if BEHAVIOR_V4 || BEHAVIOR_V5
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [DynamicData(nameof(WithDefaultAttribute_Data))]
        [DataTestMethod]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void WithDefaultAttribute(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Expected, instance.Value);
        }


#if BEHAVIOR_V4
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [DynamicData(nameof(WithDefaultAndAttribute_Data))]
        [DataTestMethod]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void WithDefaultAndAttribute(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Expected, instance.Value);
        }
    }
}
