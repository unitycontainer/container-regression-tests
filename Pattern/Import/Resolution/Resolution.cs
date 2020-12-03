using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Import
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Resolution(string test, Type type,
                                       object defaultValue, object defaultAttr,
                                       object registered, object named,
                                       object injected, object overridden,
                                       object @default)
            => Assert_Resolved(BaselineTestType.MakeGenericType(type), registered);


        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Registered_Unresolvable(string test, Type type)
        {
            // Arrange
            RegisterUnResolvableTypes();

            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
        }

        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Registered_Unresolvable_Import(string test, Type type)
        {
            // Arrange
            RegisterUnResolvableTypes();
            var target = BaselineTestType.MakeGenericType(type);


            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(Container.Resolve(type, null), instance.Value);
        }

    }
}
