using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        public object Assert_Resolution(Type type)
        {
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            return instance;
        }

        protected virtual void Assert_Resolution(Type type, object expected)
        {
            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(type, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }
    }
}
