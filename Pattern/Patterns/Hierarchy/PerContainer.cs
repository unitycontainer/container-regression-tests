using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif


namespace Container
{
    public abstract partial class Pattern
    {
        [TestMethod("Resolve Singleton Directly In Root Container In All Child Containers")]
        [DynamicData(nameof(Hierarchy_Unnamed_Data)), TestProperty(HIERARCHY, nameof(ContainerControlledLifetimeManager))]
        public void ResolveSingleton_Directly_InRootContainer(Type type)
        {
            var target = type.MakeGenericType(typeof(IUnityContainer), typeof(IUnityContainer));
            Container.RegisterType(target, new ContainerControlledLifetimeManager());

            var rootContainerId = Container.GetHashCode();
            var childContainer1 = Container.CreateChildContainer();
            var childContainer2 = Container.CreateChildContainer();

            var instanceFromRootContainer = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChildContainer1 = childContainer1.Resolve(target) as FixtureBaseType;
            var instanceFromChildContainer2 = childContainer2.Resolve(target) as FixtureBaseType;

            Assert.AreEqual(rootContainerId, instanceFromRootContainer.Value.GetHashCode(), "instanceFromRootContainer should be created in root container");
            Assert.AreEqual(rootContainerId, instanceFromChildContainer1.Value.GetHashCode(), "instanceFromChildContainer1 should be created in root container");
            Assert.AreEqual(rootContainerId, instanceFromChildContainer2.Value.GetHashCode(), "instanceFromChildContainer2 should be created in root container");

            Assert.AreEqual(instanceFromRootContainer, instanceFromChildContainer1, "instanceFromRootContainer and instanceFromChildContainer1 must be same");
            Assert.AreEqual(instanceFromRootContainer, instanceFromChildContainer2, "instanceFromRootContainer and instanceFromChildContainer2 must be same");
        }


        [TestMethod("Resolve Singleton Directly In Child THEN All Child Containers AND In Root")]
        [DynamicData(nameof(Hierarchy_Unnamed_Data)), TestProperty(HIERARCHY, nameof(ContainerControlledLifetimeManager))]
        public void ResolveSingleton_Directly_InChildContainer(Type type)
        {
            var target = type.MakeGenericType(typeof(IUnityContainer), typeof(IUnityContainer));
            Container.RegisterType(target, new ContainerControlledLifetimeManager());

            var rootContainerId = Container.GetHashCode();
            var childContainer1 = Container.CreateChildContainer();
            var childContainer2 = Container.CreateChildContainer();
            var childContainer11 = childContainer1.CreateChildContainer();

            var instanceFromChildContainer11 = childContainer11.Resolve(target) as FixtureBaseType;
            var instanceFromChildContainer1 = childContainer1.Resolve(target) as FixtureBaseType;
            var instanceFromChildContainer2 = childContainer2.Resolve(target) as FixtureBaseType;
            var instanceFromRootContainer = Container.Resolve(target) as FixtureBaseType;

            Assert.AreEqual(rootContainerId, instanceFromChildContainer1.Value.GetHashCode(), "instanceFromChildContainer1 should be created in root container");
            Assert.AreEqual(rootContainerId, instanceFromChildContainer2.Value.GetHashCode(), "instanceFromChildContainer2 should be created in root container");
            Assert.AreEqual(rootContainerId, instanceFromChildContainer11.Value.GetHashCode(), "instanceFromChildContainer11 should be created in root container");
            Assert.AreEqual(rootContainerId, instanceFromRootContainer.Value.GetHashCode(), "instanceFromRootContainer should be created in root container");

            Assert.AreEqual(instanceFromRootContainer, instanceFromChildContainer1, "instanceFromRootContainer and instanceFromChildContainer1 must be same");
            Assert.AreEqual(instanceFromRootContainer, instanceFromChildContainer2, "instanceFromRootContainer and instanceFromChildContainer2 must be same");
            Assert.AreEqual(instanceFromRootContainer, instanceFromChildContainer11, "instanceFromRootContainer and instanceFromChildContainer11 must be same");
        }


        [TestMethod("Resolve Singleton As Dependency In Root Container")]
        [DynamicData(nameof(Hierarchy_Unnamed_Data)), TestProperty(HIERARCHY, nameof(ContainerControlledLifetimeManager))]
        public void ResolveSingletonType_AsDependency_InRootContainer(Type type)
        {
            Container.RegisterType(typeof(ISingletonService), typeof(SingletonService), new ContainerControlledLifetimeManager());

            var target = type.MakeGenericType(typeof(ISingletonService), typeof(IUnityContainer));

            var consumerInstanceFromRootContainter = Container.Resolve(target) as FixtureBaseType;
            var service = consumerInstanceFromRootContainter.Value as SingletonService;

            Assert.AreEqual(Container.GetHashCode(), consumerInstanceFromRootContainter.Default.GetHashCode(), "consumerInstanceFromRootContainter should be created in root container");
            Assert.AreEqual(Container.GetHashCode(), service.ContainerId, "SingletonService dependency of consumerInstanceFromRootContainter should be created in root container");
        }

#if !BEHAVIOR_V4 && !BEHAVIOR_V5
        [TestMethod("Resolve Singleton As Dependency In Child Container THEN_ConsumerInstance_CreatedInChildContiner_AND_SignletonInstance_CreatedInRootContainer")]
        [DynamicData(nameof(Hierarchy_Unnamed_Data)), TestProperty(HIERARCHY, nameof(ContainerControlledLifetimeManager))]
        public void ResolveSingletonType_AsDependency_InChildContainer(Type type)
        {
            Container.RegisterType(typeof(ISingletonService), typeof(SingletonService), new ContainerControlledLifetimeManager());
            
            var target = type.MakeGenericType(typeof(ISingletonService), typeof(IUnityContainer));

            var childContainer1 = Container.CreateChildContainer()
                                           .RegisterType(target, new TransientLifetimeManager());
            var childContainer2 = childContainer1.CreateChildContainer();

            var consumerInstanceFromChildContainter2 = childContainer2.Resolve(target) as FixtureBaseType;
            var service = consumerInstanceFromChildContainter2.Value as SingletonService;
            var container = consumerInstanceFromChildContainter2.Default;

            Assert.AreSame(childContainer1, container, "consumerInstanceFromRootContainter should be created in root container");
            Assert.AreEqual(Container.GetHashCode(), service.ContainerId, "singletonService dependency of consumerInstanceFromRootContainter should be created in root container");
        }
#endif
    }
}
