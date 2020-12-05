using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        public object Assert_ResolutionSuccess(Type type)
        {
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            return instance;
        }

        protected virtual void Assert_Fail(Type type, InjectionMember member)
        {
            Container.RegisterType(null, type, null, null, member);

            // Validate
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(type, null));

            // Register missing types
            RegisterTypes();

            // Act
            _ = Container.Resolve(type, null);
        }

        public void Assert_Lazy_Import(Type type, object expected)
        {
            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Value);
            Assert.IsInstanceOfType(instance, type);

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

            instance = Container.Resolve(type, null) as FixtureBaseType;

            // Act
            var value = instance.Value switch
            {
                Lazy<int> integer => integer.Value,
                Lazy<string> letters => letters.Value,
                Lazy<Unresolvable> unresolvable => (object)unresolvable.Value,
                _ => throw new NotImplementedException(),
            };

            // Validate
            Assert.AreEqual(expected, value);
        }

        public void Assert_Func_Import(Type type, object expected)
        {
            // Act
            var instance = Container.Resolve(type, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Value);
            Assert.IsInstanceOfType(instance, type);

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
            Assert.AreEqual(expected, value);
        }
    }
}
