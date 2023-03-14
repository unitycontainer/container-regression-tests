using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Lifetime
{
    public partial class Managers
    {
        /// <summary>
        /// Registering var type twice with SetSingleton method. once with default and second with name.
        /// </summary>
        [TestMethod, TestProperty(LIFETIME_MANAGER, INSTANCE_DEFAULT)]
        public void Instance_CheckRegisterInstanceDoneTwice()
        {
            var aInstance = new Service();
            Container.RegisterInstance<Service>(aInstance)
                     .RegisterInstance<Service>("hello", aInstance);

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");
            
            Assert.AreSame(obj, aInstance);
            Assert.AreSame(obj1, aInstance);
            Assert.AreSame(obj, obj1);
        }

        /// <summary>
        /// SetSingleton class A. Then register instance of class var twice. once by default second by name.
        /// </summary>
        [TestMethod, TestProperty(LIFETIME_MANAGER, INSTANCE_DEFAULT)]
        public void Instance_SetSingletonRegisterInstanceTwice()
        {
            var aInstance = new Service();
            Container.RegisterInstance<Service>(aInstance).RegisterInstance<Service>("hello", aInstance);
            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");
            
            Assert.AreSame(obj, obj1);
        }
    }
}