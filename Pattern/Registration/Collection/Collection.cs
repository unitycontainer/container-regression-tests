using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Registration
{
    public partial class Collection
    {
        [TestMethod]
        public void IsNotNull()
        {
            Assert.IsNotNull(Container.Registrations);
        }

        [TestMethod]
        public void ContainerIncludesItselfUnderRegistrations()
        {
            Assert.IsNotNull(Container.Registrations.Where(r => r.RegisteredType == typeof(IUnityContainer)).FirstOrDefault());
        }

        [TestMethod]
        public void NewRegistrationsShowUpInRegistrationsSequence()
        {
            Container.RegisterType<ILogger, MockLogger>()
                     .RegisterType<ILogger, MockLogger>("second");

            var registrations = (from r in Container.Registrations
                                 where r.RegisteredType == typeof(ILogger)
                                 select r).ToList();

            Assert.AreEqual(2, registrations.Count);

            Assert.IsTrue(registrations.Any(r => r.Name == null));
            Assert.IsTrue(registrations.Any(r => r.Name == "second"));
        }

        [TestMethod]
        public void TypeMappingShowsUpInRegistrationsCorrectly()
        {
            Container.RegisterType<ILogger, MockLogger>();

            var registration =
                (from r in Container.Registrations where r.RegisteredType == typeof(ILogger) select r).First();
            Assert.AreSame(typeof(MockLogger), registration.MappedToType);
        }

        [TestMethod]
        public void NonMappingRegistrationShowsUpInRegistrationsSequence()
        {
            Container.RegisterType<MockLogger>();
            var registration = (from r in Container.Registrations
                                where r.RegisteredType == typeof(MockLogger)
                                select r).First();

            Assert.AreSame(registration.RegisteredType, registration.MappedToType);
            Assert.IsNull(registration.Name);
        }

        [TestMethod]
        public void RegistrationsInParentContainerAppearInChild()
        {
            Container.RegisterType<ILogger, MockLogger>();
            var child = Container.CreateChildContainer();

            var registration =
                (from r in child.Registrations where r.RegisteredType == typeof(ILogger) select r).First();

            Assert.AreSame(typeof(MockLogger), registration.MappedToType);
        }

        [TestMethod]
        public void RegistrationsInChildContainerDoNotAppearInParent()
        {
            var child = Container.CreateChildContainer()
                .RegisterType<ILogger, MockLogger>("named");

            var childRegistration = child.Registrations
                                         .Cast<IContainerRegistration>()
                                         .Where(r => r.RegisteredType == typeof(ILogger))
                                         .First();
            
            var parentRegistration = Container.Registrations
                                              .Cast<IContainerRegistration>()
                                              .Where(r => r.RegisteredType == typeof(ILogger))
                                              .FirstOrDefault();

            Assert.IsNull(parentRegistration);
            Assert.IsNotNull(childRegistration);
        }

        [TestMethod]
        public void RegistrationsInParentAndChildShowUpInChild()
        {
            Container.RegisterType<IService, Service>();

            var child = Container.CreateChildContainer()
                .RegisterType<IService, OtherService>();

            var registrations = from r in child.Registrations
                                where r.RegisteredType == typeof(ILogger)
                                select r;


#if BEHAVIOR_V4 || BEHAVIOR_V5
            Assert.AreEqual(, registrations.Count());
            var childRegistration = registrations.First();
            Assert.AreSame(typeof(OtherService), childRegistration.MappedToType);
#else
            Assert.AreEqual(2, registrations.Count());
            var childRegistration = registrations.First();
            Assert.AreNotSame(typeof(OtherService), childRegistration.MappedToType);
#endif
        }

        [TestMethod]
        public void NamedRegistrationsInParentAndChildOnlyShowUpOnceInChild()
        {
            Container.RegisterType<IService, Service>("one");

            var child = Container.CreateChildContainer()
                .RegisterType<IService, OtherService>("one");

            var registrations = from r in child.Registrations
                                where r.RegisteredType == typeof(ILogger)
                                select r;

            Assert.AreEqual(1, registrations.Count());

            var childRegistration = registrations.First();
            Assert.AreSame(typeof(OtherService), childRegistration.MappedToType);
            Assert.AreEqual("one", childRegistration.Name);
        }

        [Ignore]
        [TestMethod]
        public void WhenRegistrationsAreRetrievedFromAContainer()
        {
            //Container.RegisterType<IService, Service>(Invoke.Constructor("default"));
            //Container.RegisterType<IService, OtherService>("foo", Invoke.Constructor("foo"));

            //var registrations = Container.Registrations;


            //var @default = registrations.SingleOrDefault(c => c.Name == null &&
            //                                               c.RegisteredType == typeof(ILogger));

            //Assert.IsNotNull(@default);
            //Assert.AreEqual(typeof(MockLoggerWithCtor), @default.MappedToType);

            //var foo = registrations.SingleOrDefault(c => c.Name == "foo");

            //Assert.IsNotNull(foo);
            //Assert.AreEqual(typeof(MockLoggerWithCtor), @default.MappedToType);
        }

        [Ignore]
        [TestMethod]
        public void WhenRegistrationsAreRetrievedFromANestedContainer()
        {
            //Container.RegisterType<ILogger, MockLoggerWithCtor>(Invoke.Constructor("default"));
            //Container.RegisterType<ILogger, MockLoggerWithCtor>("foo", Invoke.Constructor("foo"));

            //var child = Container.CreateChildContainer();

            //child.RegisterType<ISpecialLogger, SpecialLoggerWithCtor>(Invoke.Constructor("default"));
            //child.RegisterType<ISpecialLogger, SpecialLoggerWithCtor>("another", Invoke.Constructor("another"));

            //var registrations = Container.Registrations;

            //var mappedCount = child.Registrations.Where(c => c.MappedToType == typeof(SpecialLoggerWithCtor)).Count();

            //Assert.AreEqual(2, mappedCount);
        }

        [Ignore]
        [TestMethod]
        public void WhenRegistrationsAreRetrievedFromAContainerByLifeTimeManager()
        {
            //Container.RegisterType<ILogger, MockLoggerWithCtor>(       TypeLifetime.PerResolve, Invoke.Constructor("default"));
            //Container.RegisterType<ILogger, MockLoggerWithCtor>("foo", TypeLifetime.PerResolve, Invoke.Constructor("foo"));

            //var registrations = Container.Registrations;

            //var count = registrations.Where(c => c.LifetimeManager?.GetType() == typeof(PerResolveLifetimeManager)).Count();

            //Assert.AreEqual(2, count);
        }

    }
}
