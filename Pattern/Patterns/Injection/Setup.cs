using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Injection
{
    public abstract partial class Pattern : FixtureBase
    {
        #region Runners

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

        #endregion

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
