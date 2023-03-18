using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
#if !UNITY_V4
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_Instance_Null()
        {
            // Arrange

            Container.RegisterInstance(typeof(IService), null, null, new ContainerControlledLifetimeManager());
            // Act
            var instance = Container.Resolve<IService>();

            // Validate
            Assert.IsNull(instance);
            Assert.IsNull(Container.Resolve<IService>());
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_Factory_Null()
        {
            // Arrange
            Container.RegisterFactory<IService>(c => null, new ContainerControlledLifetimeManager());

            // Act
            var instance = Container.Resolve<IService>();

            // Validate
            Assert.IsNull(instance);
            Assert.IsNull(Container.Resolve<IService>());
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_GenericWithInstances()
        {
            Container.RegisterSingleton(typeof(IFoo<>), typeof(Foo<>));

            var rootContainer = Container as IUnityContainer;

            var childContainer1 = rootContainer.CreateChildContainer();
            var childContainer2 = rootContainer.CreateChildContainer();

            childContainer1.RegisterInstance<IService>(new Service());
            childContainer2.RegisterInstance<IService>(new Service());

            var test1 = childContainer1.Resolve<IFoo<object>>();
            var test2 = childContainer2.Resolve<IFoo<object>>();

            Assert.AreSame(test1, test2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_Generic()
        {
            Container.RegisterSingleton(typeof(IFoo<>), typeof(Foo<>));

            var rootContainer = Container as IUnityContainer;

            var childContainer1 = rootContainer.CreateChildContainer();
            var childContainer2 = rootContainer.CreateChildContainer();

            var test1 = childContainer1.Resolve<IFoo<object>>();
            var test2 = childContainer2.Resolve<IFoo<object>>();

            Assert.AreSame(test1, test2);
        }
#endif

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_CheckSetSingletonDoneTwice()
        {
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager())
                     .RegisterType<Service>("hello", new ContainerControlledLifetimeManager());

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");

            Assert.AreNotSame(obj, obj1);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_CheckSingletonWithDependencies()
        {
            Container.RegisterType<ObjectWithOneDependency>(new ContainerControlledLifetimeManager());

            var result1 = Container.Resolve<ObjectWithOneDependency>();
            var result2 = Container.Resolve<ObjectWithOneDependency>();

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.IsNotNull(result1.InnerObject);
            Assert.IsNotNull(result2.InnerObject);
            Assert.AreSame(result1, result2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_CheckSingletonAsDependencies()
        {
            Container.RegisterType<ObjectWithOneDependency>(new ContainerControlledLifetimeManager());

            var result1 = Container.Resolve<ObjectWithTwoConstructorDependencies>();
            var result2 = Container.Resolve<ObjectWithTwoConstructorDependencies>();

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.IsNotNull(result1.OneDep);
            Assert.IsNotNull(result2.OneDep);
            Assert.AreNotSame(result1, result2);
            Assert.AreSame(result1.OneDep, result2.OneDep);
        }


        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_SetLifetimeTwiceWithLifetimeHandle()
        {
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager())
              .RegisterType<Service>("hello", new HierarchicalLifetimeManager());
            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");

            Assert.AreNotSame(obj, obj1);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_SetLifetimeGetTwice()
        {
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager());
            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");

            Assert.AreNotSame(obj, obj1);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_SetSingletonRegisterInstanceTwiceSetLifetimeTwice()
        {
            var aInstance = new Service();

            Container.RegisterInstance(aInstance);
            Container.RegisterInstance("hello", aInstance);
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager());
            Container.RegisterType<Service>("hello1", new ContainerControlledLifetimeManager());

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello1");

            Assert.AreNotSame(obj, obj1);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_SetSingletonByNameRegisterInstanceOnit()
        {
            var aInstance = new Service();
            Container.RegisterType<Service>("SetA", new ContainerControlledLifetimeManager())
                .RegisterInstance<Service>(aInstance)
                .RegisterInstance<Service>("hello", aInstance);

            var obj = Container.Resolve<Service>("SetA");
            var obj1 = Container.Resolve<Service>();
            var obj2 = Container.Resolve<Service>("hello");

            Assert.AreSame(obj1, obj2);
            Assert.AreNotSame(obj, obj2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_TestSetLifetime()
        {
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager())
               .RegisterType<Service>("hello", new ContainerControlledLifetimeManager());

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("hello");

            Assert.AreNotSame(obj, obj1);
        }

#if BEHAVIOR_V4
        [Ignore("Known bug")]
#endif
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_SetSingletonDefaultNameRegisterInstance()
        {
            var aInstance = new Service();

            Container.RegisterType((Type)null, typeof(Service), null, new ContainerControlledLifetimeManager(), null);
            Container.RegisterType((Type)null, typeof(Service), "SetA", new ContainerControlledLifetimeManager(), null);
            Container.RegisterInstance(aInstance);
            Container.RegisterInstance("hello", aInstance);
            Container.RegisterInstance("hello", aInstance, new ExternallyControlledLifetimeManager());

            var obj = Container.Resolve<Service>();
            var obj1 = Container.Resolve<Service>("SetA");
            var obj2 = Container.Resolve<Service>("hello");

            Assert.AreNotSame(obj, obj1);
            Assert.AreSame(obj, obj2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_RegisterWithParentAndChild()
        {
            //register type UnityTestClass
            var child = Container.CreateChildContainer();

            Container.RegisterType<Service>(new ContainerControlledLifetimeManager());
            child.RegisterType<Service>(new ContainerControlledLifetimeManager());

            var mytestparent = Container.Resolve<Service>();
            var mytestchild = child.Resolve<Service>();

            Assert.AreNotSame(mytestparent, mytestchild);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_UseContainerControlledLifetime()
        {
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager());

            var parentinstance = Container.Resolve<Service>();
            var hash = parentinstance.GetHashCode();
            parentinstance = null;
            GC.Collect();

            var parentinstance1 = Container.Resolve<Service>();
            Assert.AreEqual(hash, parentinstance1.GetHashCode());
        }

#if !UNITY_V4
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_TestStringEmpty()
        {
            Container.RegisterType<Service>(null, new ContainerControlledLifetimeManager());
            Container.RegisterType<Service>(string.Empty, new ContainerControlledLifetimeManager());

            Service a = Container.Resolve<Service>();
            Service c = Container.Resolve<Service>((string)null);
            Service b = Container.Resolve<Service>(string.Empty);

            Assert.AreNotEqual(a, b);
            Assert.AreNotEqual(b, c);
            Assert.AreEqual(a, c);
        }


        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_SameRegistrationFromMultipleThreads()
        {
            Container.RegisterFactory<IService>((c, t, n) => new Service(), FactoryLifetime.PerContainer);

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
            Assert.AreSame(result1, result2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_SameRegistrationFromMultipleThreadsGeneric()
        {
            Container.RegisterFactory<IService>((c, t, n) => new Service(), FactoryLifetime.PerContainer)
                     .RegisterType(typeof(IFoo<>), typeof(Foo<>), new ContainerControlledLifetimeManager());

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
            Assert.AreSame(result1, result2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(ContainerControlledLifetimeManager))]
        public void PerContainer_DoesNotLeaveHangingLockIfBuildThrowsException()
        {
            int count = 0;
            bool fail = false;
            Func<IUnityContainer, Type, string, object> factory = (c, t, n) =>
            {
                fail = !fail;
                Interlocked.Increment(ref count);
                return !fail ? new Service() : throw new InvalidOperationException();
            };
            Container.RegisterFactory<IService>(factory, FactoryLifetime.PerContainer);

            bool failed = true;
            object result1 = null;
            object result2 = null;
            bool thread2Finished = false;

            Thread thread1 = new Thread(
                delegate ()
                {
                    try
                    {
                        result1 = Container.Resolve<IService>();
                    }
                    catch (ResolutionFailedException) { /* ignore */ }
                    catch (Exception)
                    {
                        // Make sure user exception is passed through
                        failed = false;
                    }
                });

            Thread thread2 = new Thread(
                delegate ()
                {
                    result2 = Container.Resolve<IService>();
                    thread2Finished = true;
                });

            thread1.Start();
            thread1.Join();

            // Thread1 threw an exception. However, lock should be correctly freed.
            // Run thread2, and if it finished, we're ok.

            thread2.Start();
            thread2.Join(500);
            //thread2.Join();

            Assert.IsFalse(failed);
            Assert.IsTrue(thread2Finished);
            Assert.IsNull(result1);
            Assert.IsNotNull(result2);
        }
#endif
    }
}
