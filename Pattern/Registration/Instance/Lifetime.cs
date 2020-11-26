using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Registration
{
    public partial class Instance
    {
        [TestMethod]
        public void SingletonAtRoot()
        {
            // Arrange
            var service = Unresolvable.Create("SingletonAtRoot");

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            Container.RegisterInstance(typeof(IService), null, service, new ContainerControlledLifetimeManager());


            // Act/Verify

            Assert.AreSame(service, Container.Resolve<IService>());
            Assert.AreSame(service, child1.Resolve<IService>());
            Assert.AreSame(service, child2.Resolve<IService>());
        }

        [TestMethod]
        public void SingletonAtChild()
        {
            // Arrange
            var service = Unresolvable.Create("SingletonAtChild");

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            child1.RegisterInstance(typeof(IService), null, service, new ContainerControlledLifetimeManager());


            // Act/Verify

            Assert.AreSame(service, Container.Resolve<IService>());
            Assert.AreSame(service, child1.Resolve<IService>());
            Assert.AreSame(service, child2.Resolve<IService>());
        }

        [TestMethod]
        public void PerContainerAtRoot()
        {
            // Arrange
            var service = Unresolvable.Create("PerContainerAtRoot");

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            Container.RegisterInstance(typeof(IService), null, service, InstanceLifetime.PerContainer);


            // Act/Verify

            Assert.AreSame(service, Container.Resolve<IService>());
            Assert.AreSame(service, child1.Resolve<IService>());
            Assert.AreSame(service, child2.Resolve<IService>());
        }

        [TestMethod]
        public void PerContainerAtChild()
        {
            // Arrange
            var service = Unresolvable.Create("PerContainerAtChild");

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            Container.RegisterInstance(typeof(IService), null, Unresolvable.Create("1"), InstanceLifetime.PerContainer);
            child1.RegisterInstance(typeof(IService), null, Unresolvable.Create("2"), InstanceLifetime.PerContainer);
            child2.RegisterInstance(typeof(IService), null, Unresolvable.Create("3"), InstanceLifetime.PerContainer);


            // Act/Verify

            Assert.AreNotSame(service, Container.Resolve<IService>());
            Assert.AreNotSame(service, child1.Resolve<IService>());
            Assert.AreNotSame(service, child2.Resolve<IService>());
        }

        [TestMethod]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void PerContainerThrows()
        {
            // Arrange
            var child1 = Container.CreateChildContainer();

            child1.RegisterInstance(typeof(IService), null, Unresolvable.Create("PerContainerThrows"), InstanceLifetime.PerContainer);

            // Act/Verify
            var result = Container.Resolve<IService>();
        }


        [TestMethod]
        public void ExternalAtRoot()
        {
            // Arrange
            var service = Unresolvable.Create("ExternalAtRoot");

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            Container.RegisterInstance(typeof(IService), null, service, InstanceLifetime.External);


            // Act/Verify

            Assert.AreSame(service, Container.Resolve<IService>());
            Assert.AreSame(service, child1.Resolve<IService>());
            Assert.AreSame(service, child2.Resolve<IService>());
        }

        [TestMethod]
        public void ExternalAtChild()
        {
            // Arrange
            var service = Unresolvable.Create("ExternalAtChild");

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            Container.RegisterInstance(typeof(IService), null, Unresolvable.Create("1"), InstanceLifetime.External);
            child1.RegisterInstance(typeof(IService), null, Unresolvable.Create("2"), InstanceLifetime.External);
            child2.RegisterInstance(typeof(IService), null, Unresolvable.Create("3"), InstanceLifetime.External);


            // Act/Verify

            Assert.AreNotSame(service, Container.Resolve<IService>());
            Assert.AreNotSame(service, child1.Resolve<IService>());
            Assert.AreNotSame(service, child2.Resolve<IService>());
        }

        [TestMethod]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void ExternalThrows()
        {
            // Arrange
            var child1 = Container.CreateChildContainer();

            child1.RegisterInstance(typeof(IService), null, Unresolvable.Create("ExternalThrows"), InstanceLifetime.External);

            // Act/Verify
            var result = Container.Resolve<IService>();
        }
    }
}
