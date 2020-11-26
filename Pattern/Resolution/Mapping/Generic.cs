using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Resolution
{
    public partial class Mapping
    {
        [TestMethod]
        public void GenericClosed()
        {
            // Arrange
            Container.RegisterInstance(55);
            Container.RegisterType(typeof(Foo<int>), new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(IFoo1<int>), typeof(Foo<int>));
            Container.RegisterType(typeof(IFoo2<int>), typeof(Foo<int>));

            // Act
            var service1 = Container.Resolve<IFoo1<int>>();
            var service2 = Container.Resolve<IFoo2<int>>();

            // Assert
            Assert.IsNotNull(service1);
            Assert.IsNotNull(service2);

            Assert.AreSame(service1, service2);
        }

        [TestMethod]
        public void GenericOpen()
        {
            // Arrange
            Container.RegisterInstance(55)
                     .RegisterType(typeof(Foo<>), new ContainerControlledLifetimeManager())
                     .RegisterType(typeof(IFoo1<>), typeof(Foo<>))
                     .RegisterType(typeof(IFoo2<>), typeof(Foo<>));

            // Act
            var service1 = Container.Resolve<IFoo1<int>>();
            var service2 = Container.Resolve<IFoo2<int>>();

            // Assert
            Assert.IsNotNull(service1);
            Assert.IsNotNull(service2);

            Assert.AreSame(service1, service2);
        }

        [TestMethod]
        public void OpenGenericServicesCanBeResolved()
        {
            // Arrange
            Container.RegisterType<IService, Service>(new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(IFoo<>), typeof(Foo<>));

            // Act
            var genericService = Container.Resolve<IFoo<IService>>();
            var singletonService = Container.Resolve<IService>();

            // Assert
            Assert.AreSame(singletonService, genericService.Value);
        }

        [TestMethod]
        public void ClosedServicesPreferredOverOpenGenericServices()
        {
            // Arrange
            Container.RegisterType<IService, Service>();
            Container.RegisterType(typeof(IFoo<>), typeof(Foo<>));
            Container.RegisterType(typeof(IFoo<IService>), typeof(Foo<IService>));

            // Act
            var service = Container.Resolve<IFoo<IService>>();

            // Assert
            Assert.IsInstanceOfType(service.Value, typeof(Service));
        }
    }
}
