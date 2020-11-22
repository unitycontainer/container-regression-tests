using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated
{
    public abstract partial class Pattern
    {
        [DataTestMethod]
        [DynamicData(nameof(UnResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Required_Registered_Invalid(string test, Type type)
        {
            // Arrange
            RegisterUnResolvableTypes();
            var target = (_typeDefinition ??= GetType("Required", "BaselineTestType`1"))
                .MakeGenericType(type);


            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(Container.Resolve(type, null), instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(UnResolvableTypes_Data), typeof(PatternBase))]
        public virtual void Optional_Registered_Invalid(string test, Type type)
        {
            // Arrange
            RegisterUnResolvableTypes();
            var target = (_typeDefinition ??= GetType("Optional", "BaselineTestType`1"))
                .MakeGenericType(type);

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(Container.Resolve(type, null), instance.Value);
        }
    }
}
