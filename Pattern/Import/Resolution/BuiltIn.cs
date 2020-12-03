using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import
{
    public abstract partial class Pattern
    {
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void BuiltIn_Array(string test, Type type, object defaultValue, object defaultAttr, object registered,
                                  object named, object injected, object overridden, object @default)
        {
            // Arrange
            var target = BaselineTestType.MakeGenericType(type.MakeArrayType());

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(0, (instance.Value as IList)?.Count ?? -1);

            RegisterArrayTypes();

            // Act
            instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
#if BEHAVIOR_V4
            Assert.AreEqual(3, (instance.Value as IList)?.Count ?? -1);
#else
            Assert.AreEqual(4, (instance.Value as IList)?.Count ?? -1);
#endif
        }


#if !BEHAVIOR_V4
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void BuiltIn_Enumerable(string test, Type type, object defaultValue, object defaultAttr, object registered,
                                       object named, object injected, object overridden, object @default)
        {
            // Arrange
            var target = BaselineTestType.MakeGenericType(typeof(IEnumerable<>).MakeGenericType(type));

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(0, (instance.Value as IEnumerable)?.Cast<object>().Count() ?? -1);

            RegisterArrayTypes();

            // Act
            instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.AreEqual(5, (instance.Value as IEnumerable)?.Cast<object>().Count() ?? -1);
        }
#endif


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void BuiltIn_Lazy(string test, Type type, object defaultValue, object defaultAttr, object registered,
                                 object named, object injected, object overridden, object @default)
        {
            // Arrange
            var target = BaselineTestType.MakeGenericType(typeof(Lazy<>).MakeGenericType(type));

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Value);
            Assert.IsInstanceOfType(instance, target);

            Assert.ThrowsException<ResolutionFailedException>(() =>
            {
                switch (instance.Value)
                {
                    case Lazy<int> integer:
                        _ = integer.Value;
                        break;

                    case Lazy<string> letters:
                        _ = letters.Value;
                        break;

                    case Lazy<Unresolvable> unresolvable:
                        _ = unresolvable.Value;
                        break;

                    default:
                        Assert.Fail("Unknown");
                        break;
                }
            });

            RegisterTypes();

            instance = Container.Resolve(target, null) as FixtureBaseType;

            // Act
            var value = instance.Value switch
            {
                Lazy<int> integer => integer.Value,
                Lazy<string> letters => letters.Value,
                Lazy<Unresolvable> unresolvable => (object)unresolvable.Value,
                _ => throw new NotImplementedException(),
            };

            // Validate
            Assert.AreEqual(registered, value);
        }


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void BuiltIn_Func(string test, Type type, object defaultValue, object defaultAttr, object registered,
                                 object named, object injected, object overridden, object @default)
        {
            // Arrange
            var target = BaselineTestType.MakeGenericType(typeof(Func<>).MakeGenericType(type));

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Value);
            Assert.IsInstanceOfType(instance, target);

            Assert.ThrowsException<ResolutionFailedException>(() =>
            {
                switch (instance.Value)
                {
                    case Func<int> integer:
                        _ = integer();
                        break;

                    case Func<string> letters:
                        _ = letters();
                        break;

                    case Func<Unresolvable> unresolvable:
                        _ = unresolvable();
                        break;

                    default:
                        Assert.Fail("Unknown");
                        break;
                }
            });

            RegisterTypes();

            // Act
            var value = instance.Value switch
            {
                Func<int> integer => (object)integer(),
                Func<string> letters => (object)letters(),
                Func<Unresolvable> unresolvable => (object)unresolvable(),
                _ => throw new NotImplementedException(),
            };

            // Validate
            Assert.AreEqual(registered, value);
        }


        [DataTestMethod, DynamicData(nameof(BuiltInTypes_Data), typeof(FixtureBase))]
        public virtual void BuiltIn_Interface(string test, Type type) 
            => Assert_Resolved(type);


        [DataTestMethod, DynamicData(nameof(BuiltInTypes_Data), typeof(FixtureBase))]
        public virtual void BuiltIn_Interface_Import(string test, Type type)
            => Assert_Resolved(BaselineTestType.MakeGenericType(type));


        [DataTestMethod, DynamicData(nameof(BuiltInTypes_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void BuiltIn_Interface_Named(string test, Type type)
        {
            // Arrange
            // Act
            _ = Container.Resolve(type, Name) as FixtureBaseType;
        }
    }
}
