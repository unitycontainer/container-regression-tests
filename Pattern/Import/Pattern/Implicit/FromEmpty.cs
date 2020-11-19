using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class ImplicitPattern
    {
        [DataTestMethod]
        [DynamicData(nameof(ResolvableFromEmpty_Data), typeof(PatternBase))]
        public virtual void ResolvableFromEmpty(string test, Type type, string name, Type expected)
        {
            // Act
            var instance = Container.Resolve(type, name);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, expected);
        }

        /// <summary>
        /// Tests exception throwing on unsatisfactory resolution.
        /// </summary>
        [DataTestMethod]
        [DynamicData(nameof(UnResolvableFromEmpty_Data), typeof(PatternBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void UnResolvableFromEmpty(string test, Type type)
        {
            // Act
            _ = Container.Resolve(type, null) as PatternBaseType;
        }

    }
}
