using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(HierarchicalLifetimeManager))]
        public void Hierarchical_ResolvingInParentActsLikeContainerControlledLifetime()
        {
            Container.RegisterType<Service>(new HierarchicalLifetimeManager());

            var o1 = Container.Resolve<Service>();
            var o2 = Container.Resolve<Service>();
            Assert.AreSame(o1, o2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(HierarchicalLifetimeManager))]
        public void Hierarchical_ParentAndChildResolveDifferentInstances()
        {
            var child1 = Container.CreateChildContainer();
            Container.RegisterType<Service>(new HierarchicalLifetimeManager());

            var o1 = Container.Resolve<Service>();
            var o2 = child1.Resolve<Service>();
            Assert.AreNotSame(o1, o2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(HierarchicalLifetimeManager))]
        public void Hierarchical_ChildResolvesTheSameInstance()
        {
            var child1 = Container.CreateChildContainer();
            Container.RegisterType<Service>(new HierarchicalLifetimeManager());

            var o1 = child1.Resolve<Service>();
            var o2 = child1.Resolve<Service>();
            Assert.AreSame(o1, o2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(HierarchicalLifetimeManager))]
        public void Hierarchical_SiblingContainersResolveDifferentInstances()
        {
            var child1 = Container.CreateChildContainer();
            var child2 = Container.CreateChildContainer();
            Container.RegisterType<Service>(new HierarchicalLifetimeManager());

            var o1 = child1.Resolve<Service>();
            var o2 = child2.Resolve<Service>();
            Assert.AreNotSame(o1, o2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(HierarchicalLifetimeManager))]
        public void Hierarchical_DisposingOfChildContainerDisposesOnlyChildObject()
        {
            var child1 = Container.CreateChildContainer();
            Container.RegisterType<TestElement>(new HierarchicalLifetimeManager());

            var o1 = Container.Resolve<TestElement>();
            var o2 = child1.Resolve<TestElement>();

            child1.Dispose();
            Assert.IsFalse(o1.IsDisposed);
            Assert.IsTrue(o2.IsDisposed);
        }
    }
}
