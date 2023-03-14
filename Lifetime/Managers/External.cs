using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime
{
    public partial class Managers
    {
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ExternallyControlledLifetimeManager))]
        public void External_SetSingletonNoNameRegisterInstanceDiffNames()
        {
            var aInstance = new Service();
            Container.RegisterInstance<Service>(aInstance)
                .RegisterInstance<Service>("hello", aInstance)
                .RegisterInstance<Service>("hi", aInstance, new ExternallyControlledLifetimeManager());

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");
            var obj2 = Container.Resolve<Service>("hi");

            Assert.AreSame(obj, obj1);
            Assert.AreSame(obj1, obj2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ExternallyControlledLifetimeManager))]
        public void External_SetLifetimeNoNameRegisterInstanceDiffNames()
        {
            var aInstance = new Service();
            Container.RegisterType<Service>(TypeLifetime.PerContainer)
                .RegisterInstance<Service>(aInstance)
                .RegisterInstance<Service>("hello", aInstance)
                .RegisterInstance<Service>("hi", aInstance, new ExternallyControlledLifetimeManager());

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");
            var obj2 = Container.Resolve<Service>("hi");

            Assert.AreSame(obj, obj1);
            Assert.AreSame(obj1, obj2);
        }


        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ExternallyControlledLifetimeManager))]
        public void External_SetSingletonWithNameRegisterInstanceDiffNames()
        {
            var aInstance = new Service();
            Container.RegisterType<Service>("set", TypeLifetime.PerContainer)
                .RegisterInstance<Service>(aInstance)
                .RegisterInstance<Service>("hello", aInstance)
                .RegisterInstance<Service>("hi", aInstance, new ExternallyControlledLifetimeManager());

            var obj = Container.Resolve<Service>("set");
            var obj1 = Container.Resolve<Service>("hello");
            var obj2 = Container.Resolve<Service>("hi");

            Assert.AreNotSame(obj, obj1);
            Assert.AreSame(obj1, obj2);
            Assert.AreSame(aInstance, obj1);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ExternallyControlledLifetimeManager))]
        public void External_SetLifetimeWithNameRegisterInstanceDiffNames()
        {
            var aInstance = new Service();
            Container.RegisterType<Service>("set", TypeLifetime.PerContainer)
                .RegisterInstance<Service>(aInstance)
                .RegisterInstance<Service>("hello", aInstance)
                .RegisterInstance<Service>("hi", aInstance, new ExternallyControlledLifetimeManager());

            var obj = Container.Resolve<Service>("set");
            var obj1 = Container.Resolve<Service>("hello");
            var obj2 = Container.Resolve<Service>("hi");

            Assert.AreNotSame(obj, obj1);
            Assert.AreSame(aInstance, obj1);
            Assert.AreSame(obj1, obj2);
        }

        /// <summary>
        /// SetSingleton class A. Then register instance of class var once by default second by name and
        /// lifetime as true. Then again register instance by another name with lifetime control as true
        /// then register.
        /// Then SetLifetime once default and then by name.
        /// </summary>
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ExternallyControlledLifetimeManager))]
        public void External_SetSingletonClassARegisterInstanceOfAandBWithSameName()
        {
            var aInstance = new Service();
            var bInstance = new OtherService();
            Container.RegisterType<Service>(TypeLifetime.PerContainer)
                .RegisterInstance<Service>(aInstance)
                .RegisterInstance<Service>("hello", aInstance)
                .RegisterInstance<OtherService>("hi", bInstance)
                .RegisterInstance<OtherService>("hello", bInstance, new ExternallyControlledLifetimeManager());

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");
            var obj2 = Container.Resolve<OtherService>("hello");
            var obj3 = Container.Resolve<OtherService>("hi");

            Assert.AreSame(obj, obj1);
            Assert.AreNotSame<object>(obj, obj2);
            Assert.AreNotSame<object>(obj1, obj2);
            Assert.AreSame(obj2, obj3);
        }

    }
}
