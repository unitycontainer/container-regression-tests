using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Registration
{
    public partial class BuiltIn
    {
        [TestMethod]
        public void IServiceProvider()
        {
            var _ = Container.Registrations
                             .Select(r => r.RegisteredType)
                             .Where(t => t == typeof(IServiceProvider))
                             .First();
        }

        [TestMethod]
        public void ServiceProviderListsItselfAsRegistered()
        {
            Assert.IsTrue(Container.IsRegistered(typeof(IServiceProvider)));
        }

        [TestMethod]
        public void ServiceProviderDoesNotListItselfUnderNonDefaultName()
        {
            Assert.IsFalse(Container.IsRegistered(typeof(IServiceProvider), Name));
        }

        [TestMethod]
        public void ServiceProviderListsItselfAsRegisteredUsingGenericOverload()
        {
            Assert.IsTrue(Container.IsRegistered<IServiceProvider>());
        }

        [TestMethod]
        public void ServiceProviderDoesNotListItselfUnderNonDefaultNameUsingGenericOverload()
        {
            Assert.IsFalse(Container.IsRegistered<IServiceProvider>(Name));
        }
    }
}
