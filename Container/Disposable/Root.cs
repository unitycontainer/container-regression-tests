﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public partial class Disposal
    {
#if BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod(SafeToDisposeMultipleTimes), TestProperty(DISPOSING, ROOT)]
        public void Root_SafeToDisposeMultipleTimes()
        {
            Container.Dispose();
            Container.Dispose();
            Container.Dispose();

            Assert.IsInstanceOfType(Container.Resolve(typeof(IUnityContainer)), typeof(IUnityContainer));
        }

        [PatternTestMethod(InstanceDisposedOnlyOnce), TestProperty(DISPOSING, ROOT)]
        public void Root_DisposedOnlyOnce()
        {
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager());
            var service = Container.Resolve<Service>();

            Assert.IsFalse(service.IsDisposed);

            Container.Dispose();
            Container.Dispose();
            Container.Dispose();

            Assert.IsTrue(service.IsDisposed);
            Assert.AreEqual(1, service.Disposals);
        }

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod(InstanceAccessibleAfterDispose), TestProperty(DISPOSING, ROOT)]
        public void Root_InstanceAccessibleAfterDispose()
        {
            // Arrange
            var instance = Unresolvable.Create("root");
            Container.RegisterInstance(instance);

            // Act
            var service = Container.Resolve<Unresolvable>();
            Container.Dispose();

            Assert.AreSame(instance, service);
            Assert.AreSame(service, Container.Resolve<Unresolvable>());
        }

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod(DisposableAccessibleAfterDispose), TestProperty(DISPOSING, ROOT)]
        public void Root_DisposableAccessibleAfterDispose()
        {
            // Arrange
            Container.RegisterType<Service>(new ContainerControlledLifetimeManager());

            // Act
            var service = Container.Resolve<Service>();
            Container.Dispose();

            Assert.AreSame(service, Container.Resolve<Service>());
            Assert.IsTrue(service.IsDisposed);
            Assert.AreEqual(1, service.Disposals);
        }

#if !UNITY_V4
#if BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [ExpectedException(typeof(ObjectDisposedException))]
        [PatternTestMethod(SubsequentResolutionsDisposed), TestProperty(DISPOSING, ROOT)]
        public void Root_SubsequentResolutionsDisposed()
        {
            // Arrange
            var container = Container.RegisterType<Service>(new ContainerControlledTransientManager());

            // Act
            var before = container.Resolve<Service>();
            container.Dispose();

            var after = container.Resolve<Service>();

            Assert.IsTrue(before.IsDisposed);
            Assert.IsFalse(after.IsDisposed);

            container.Dispose();

            Assert.IsTrue(before.IsDisposed);
            Assert.IsTrue(after.IsDisposed);

            Assert.AreEqual(1, before.Disposals);
            Assert.AreEqual(1, after.Disposals);
        }

#if BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod(IgnoresExceptionDuringDisposal), TestProperty(DISPOSING, ROOT)]
        public void Root_IgnoresExceptionDuringDisposal()
        {
            // Arrange
            Container.RegisterType<ExplosiveDisposable>(new ContainerControlledTransientManager());
            // Act
            var explosive = Container.Resolve<ExplosiveDisposable>();

            Container.Dispose();

            Assert.IsTrue(explosive.IsDisposed);
        }
#endif

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod(DisposesWhenDiscarded), TestProperty(DISPOSING, ROOT)]
        public void Root_DisposesWhenDiscarded()
        {
            DisposableIndicator.IsDisposed = false;

            var (weakChild, weak) = CreateResolveDiscard();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            GC.WaitForPendingFinalizers();

            Assert.IsFalse(weak.IsAlive);
            Assert.IsFalse(weakChild.IsAlive);
            Assert.IsTrue(DisposableIndicator.IsDisposed);

            (WeakReference, WeakReference) CreateResolveDiscard()
            {
                Container.RegisterType(typeof(DisposableIndicator), new ContainerControlledLifetimeManager());

                var weak = new WeakReference(Container);
                var instance = new WeakReference(Container.Resolve<DisposableIndicator>());

                Container = new UnityContainer(); // Must replace so GC collects

                return (weak, instance);
            }
        }
    }
}
