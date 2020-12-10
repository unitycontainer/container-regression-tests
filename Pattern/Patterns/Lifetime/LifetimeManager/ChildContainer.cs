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
        [PatternTestMethod("Child Container"), TestCategory(CHILD_SCOPE)]
        public virtual void FromChildContainer(Func<LifetimeManager> factory, Type type,
                                              Action<object, object> fromSameScope,
                                              Action<object, object> fromChildScope,
                                              Action<object, object> fromSameScopeDifferentThreads,
                                              Action<object, object> fromChildScopeDifferentThreads)
        {
            // Arrange
            ArrangeTest(factory, type);

            // Act
            Item1 = Container.Resolve(TargetType);
            Item2 = Container.CreateChildContainer()
                             .Resolve(TargetType);

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);

            fromChildScope(Item1, Item2);
        }


        [DynamicData(nameof(Scope_Lifetime_Data))]
        [PatternTestMethod("Child Container as import"), TestCategory(CHILD_SCOPE)]
        public virtual void FromChildContainer_Import(Func<LifetimeManager> factory, Type type,
                                                     Action<object, object> fromSameScope,
                                                     Action<object, object> fromChildScope,
                                                     Action<object, object> fromSameScopeDifferentThreads,
                                                     Action<object, object> fromChildScopeDifferentThreads)
        {
            // Exclusion
            if (ArrangeTest(factory, type)) return;

            // Act
            Item1 = Container.Resolve<Foo<MockLogger>>().Value;
            Item2 = Container.CreateChildContainer()
                             .Resolve<Foo<MockLogger>>().Value;

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            fromChildScope(Item1, Item2);
        }


#if !BEHAVIOR_V4 // Unity v4 did not support multi-threading
        [DynamicData(nameof(Scope_Lifetime_Data))]
        [PatternTestMethod("Child Container on different threads"), TestCategory(CHILD_SCOPE)]
        public virtual void FromChildContainer_DifferentThreads(Func<LifetimeManager> factory, Type type,
                                                               Action<object, object> fromSameScope,
                                                               Action<object, object> fromChildScope,
                                                               Action<object, object> fromSameScopeDifferentThreads,
                                                               Action<object, object> fromChildScopeDifferentThreads)
        {
            // Arrange
            ArrangeTest(factory, type);

            // Act
            Thread t1 = new Thread(new ParameterizedThreadStart((c) => Item1 = Container.Resolve(TargetType)));
            Thread t2 = new Thread(new ParameterizedThreadStart((c) => Item2 = Container.CreateChildContainer()
                                                                                        .Resolve(TargetType)));

            t1.Start("1");
            t2.Start("2");
            t1.Join();
            t2.Join();

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);

            fromChildScopeDifferentThreads(Item1, Item2);
        }
#endif
    }
}
