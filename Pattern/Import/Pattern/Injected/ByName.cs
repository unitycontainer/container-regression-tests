using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    /// <summary>
    /// Tests injecting dependencies by member name
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionMethod("Method") , 
    ///                                new InjectionField("Field"), 
    ///                                new InjectionProperty("Property"));
    /// </example>
    public abstract partial class InjectedPattern
    {
        [DataTestMethod]
        [DynamicData(nameof(Test_Data), typeof(PatternBase))]
        public virtual void Injected_ByName_Implicit(string test,       Type type, 
                                                     object @default,   object defaultAttr, 
                                                     object registered, object named, 
                                                     object injected,   object overridden, 
                                                     bool isResolveble)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Implicit", "BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, Get_ByNameRequired_Member(type));

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }

        [DataTestMethod]
        [DynamicData(nameof(Test_Data), typeof(PatternBase))]
        public virtual void Injected_ByName_Required(string test, Type type,
                                                     object @default,   object defaultAttr,
                                                     object registered, object named,
                                                     object injected,   object overridden,
                                                     bool isResolveble)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Annotated", "Required.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, Get_ByNameRequired_Member(type));

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));

            // Register missing types
            RegisterTypes();

            // Act
            var instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }


        [DataTestMethod]
        [DynamicData(nameof(Test_Data), typeof(PatternBase))]
        public virtual void Injected_ByName_Optional(string test, Type type,
                                                     object defaultValue, object defaultAttr,
                                                     object registered, object named,
                                                     object injected, object overridden,
                                                     bool isResolveble)
        {
            // Arrange
            var target = (_typeDefinition ??= GetType("Annotated", "Optional.BaselineTestType`1"))
                .MakeGenericType(type);

            Container.RegisterType(target, Get_ByNameRequired_Member(type));

            // Validate
            var instance = Container.Resolve(target, null) as PatternBaseType;
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Expected, instance.Value);

            // Register missing types
            RegisterTypes();

            // Act
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(registered, instance.Value);
        }
    }
}
