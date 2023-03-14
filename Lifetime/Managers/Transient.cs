using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
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
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(TransientLifetimeManager))]
        public void Transient_Factory_Null()
        {
            // Arrange
            Container.RegisterFactory<IService>(c => null);

            // Act
            var instance = Container.Resolve<IService>();

            // Validate
            Assert.IsNull(instance);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(TransientLifetimeManager))]
        public void Transient_SameRegistrationFromMultipleThreads()
        {
            Container.RegisterFactory<IService>((c, t, n) => new Service());

            object result1 = null;
            object result2 = null;

            Thread thread1 = new Thread(delegate ()
            {
                result1 = Container.Resolve<IService>();
            });

            Thread thread2 = new Thread(delegate ()
            {
                result2 = Container.Resolve<IService>();
            });

            thread1.Name = "1";
            thread2.Name = "2";

            thread1.Start();
            thread2.Start();

            thread2.Join();
            thread1.Join();

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreNotSame(result1, result2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(TransientLifetimeManager))]
        public void Transient_SameRegistrationFromMultipleThreadsGeneric()
        {
            Container.RegisterFactory<IService>((c, t, n) => new Service())
                     .RegisterType(typeof(IFoo<>), typeof(Foo<>));

            object result1 = null;
            object result2 = null;

            Thread thread1 = new Thread(delegate ()
            {
                result1 = Container.Resolve<IFoo<IService>>();
            });

            Thread thread2 = new Thread(delegate ()
            {
                result2 = Container.Resolve<IFoo<IService>>();
            });

            thread1.Name = "1";
            thread2.Name = "2";

            thread1.Start();
            thread2.Start();

            thread2.Join();
            thread1.Join();

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreNotSame(result1, result2);
        }
    }
}
