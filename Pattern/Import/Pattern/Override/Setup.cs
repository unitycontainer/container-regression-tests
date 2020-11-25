using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Regression.Override
{
    public abstract partial class Pattern : PatternBase
    {
        #region Fields

        protected virtual string DependencyName => string.Empty;

        #endregion


        #region Runners

        protected void TestImportWithOverride(Type type, ResolverOverride @override, object value)
        {
            var instance = Container.Resolve(type, null, @override) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(value, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(type, null, @override) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(value, instance.Value);
        }

        #endregion


        #region Test Data

        public static IEnumerable<object[]> Implicit_WithDefaultValueAttribute_Data
        {
            get
            {
                foreach (var type in FromNamespaces("WithDefaultAttribute"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        public static IEnumerable<object[]> Annotated_WithDefaultValueAttribute_Data
        {
            get
            {
                foreach (var type in FromNamespaces("WithDefaults")
                    .Where(t => t.Name.EndsWith("_WithDefaultAttribute")))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        #endregion
    }
}
