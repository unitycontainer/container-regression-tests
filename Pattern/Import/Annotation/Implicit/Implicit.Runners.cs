using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Import.Implicit
{
    /// <summary>
    /// Tests invalid parameter types
    /// </summary>
    public abstract partial class Pattern
    {
        protected override void Assert_Override(Type type, ResolverOverride @override, object expected)
        {
            // Arrange
            Container.RegisterType(null, type, null, null);

            // Validate
            var instance = Container.Resolve(type, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(expected, instance.Value);
        }

    }
}
