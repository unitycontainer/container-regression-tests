using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime.Manager
{
    public abstract partial class Pattern
    {
        [DynamicData(nameof(Scope_Lifetime_Data))]
        [PatternTestMethod("Same Container"), TestCategory(SAME_SCOPE)]
        public virtual void FromSameContainer(LifetimeManager manager, Type type,
                                              Action<object, object> fromSameScope,
                                              Action<object, object> fromChildScope,
                                              Action<object, object> fromSameScopeDifferentThreads,
                                              Action<object, object> fromChildScopeDifferentThreads)
        {
            // Arrange
            ArrangeTest(manager, type);

            // Act
            Item1 = Container.Resolve(TargetType);
            Item2 = Container.Resolve(TargetType);

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);

            fromSameScope(Item1, Item2);
        }


        [DynamicData(nameof(Scope_Lifetime_Data))]
        [PatternTestMethod("Same Container as import"), TestCategory(SAME_SCOPE)]
        public virtual void FromSameContainer_Import(LifetimeManager manager, Type type,
                                                     Action<object, object> fromSameScope,
                                                     Action<object, object> fromChildScope,
                                                     Action<object, object> fromSameScopeDifferentThreads,
                                                     Action<object, object> fromChildScopeDifferentThreads)
        {
            // Exclusion
            if (manager is PerResolveLifetimeManager) return;

            // Arrange
            ArrangeTest(manager, type);

            // Act
            Item1 = Container.Resolve<Foo<MockLogger>>().Value;
            Item2 = Container.Resolve<Foo<MockLogger>>().Value;

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            fromSameScope(Item1, Item2);
        }


#if !BEHAVIOR_V4 // Unity v4 did not support multi-threading
        [DynamicData(nameof(Scope_Lifetime_Data))]
        [PatternTestMethod("Same Container on different threads"), TestCategory(SAME_SCOPE)]
        public virtual void FromSameContainer_DifferentThreads(LifetimeManager manager, Type type,
                                                               Action<object, object> fromSameScope,
                                                               Action<object, object> fromChildScope,
                                                               Action<object, object> fromSameScopeDifferentThreads,
                                                               Action<object, object> fromChildScopeDifferentThreads)
        {
            // Arrange
            ArrangeTest(manager, type);

            // Act
            Thread t1 = new Thread(new ParameterizedThreadStart((c) => Item1 = Container.Resolve(TargetType)));
            Thread t2 = new Thread(new ParameterizedThreadStart((c) => Item2 = Container.Resolve(TargetType)));

            t1.Start("1");
            t2.Start("2");
            t1.Join();
            t2.Join();

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);

            fromSameScopeDifferentThreads(Item1, Item2);
        }
#endif
    }
}
