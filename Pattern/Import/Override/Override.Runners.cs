using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class Pattern
    {
        protected virtual void Assert_Consumer(Type type, ResolverOverride @override, object value, object @default)
        {
            // Arrange
            var target = BaselineConsumer.MakeGenericType(type);
            Container.RegisterType(null, target, null, null);

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null, @override) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(value, instance.Value);
            Assert.AreEqual(@default, instance.Default);
        }
    }
}
