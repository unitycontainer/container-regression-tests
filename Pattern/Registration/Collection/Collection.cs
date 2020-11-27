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
        public void TypeRegistrationShowsUpInRegistrations()
        {
            // Act
            Container.RegisterType<MockLogger>();

            // Validate
            var registration = (from r in Container.Registrations
                                where r.RegisteredType == typeof(MockLogger)
                                select r).First();

            Assert.AreSame(registration.RegisteredType, registration.MappedToType);
            Assert.IsNull(registration.Name);
        }
        
        [TestMethod]
        public void NamedRegistrationShowsUpInRegistrations()
        {
            // Act
            Container.RegisterType<MockLogger>("name");

            // Validate
            var registration = (from r in Container.Registrations
                                where r.RegisteredType == typeof(MockLogger)
                                select r).First();

            Assert.AreSame(registration.RegisteredType, registration.MappedToType);
            Assert.AreEqual(registration.Name, "name");
        }

        [TestMethod]
        public void MappingShowsUpInRegistrations()
        {
            // Act
            Container.RegisterType<ILogger, MockLogger>();

            // Validate
            var registration =
                (from r in Container.Registrations where r.RegisteredType == typeof(ILogger) select r).First();

            Assert.AreSame(typeof(MockLogger), registration.MappedToType);
        }

        [TestMethod]
        public void NamedMappingShowUpInRegistrations()
        {
            // Act
            Container.RegisterType<ILogger, MockLogger>()
                     .RegisterType<ILogger, MockLogger>("second");

            // Validate
            var registrations = (from r in Container.Registrations
                                 where r.RegisteredType == typeof(ILogger)
                                 select r).ToList();

            Assert.AreEqual(2, registrations.Count);

            Assert.IsTrue(registrations.Any(r => r.Name == null));
            Assert.IsTrue(registrations.Any(r => r.Name == "second"));
        }
    }
}
