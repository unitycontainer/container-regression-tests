using Microsoft.VisualStudio.TestTools.UnitTesting;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Import.Override
{
    public abstract partial class Pattern : ImportBase
    {
        #region Fields

        protected virtual string DependencyName => string.Empty;

        private static Type _implicitDownTheLine;
        private static Type _requiredDownTheLine;
        private static Type _optionalDownTheLine;


        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            ImportBase.ClassInitialize(context);

            _implicitDownTheLine = GetType("Implicit", "DownTheLineType`1");
            _requiredDownTheLine = GetType("Annotated", "Required.DownTheLineType`1");
            _optionalDownTheLine = GetType("Annotated", "Optional.DownTheLineType`1");
        }

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

        protected void TestDownTheLineImportWithOverride(Type type, ResolverOverride @override, object value)
        {
            // Act
            var instance = Container.Resolve(type, null, @override) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Value);
            Assert.AreEqual(value, (instance.Value as PatternBaseType)?.Value);
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
