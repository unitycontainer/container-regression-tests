﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity.Lifetime;
using Unity.Storage;
#endif

namespace Lifetime
{
    public partial class Synchronized
    {
#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod("SetValue(object) is not added to the scope"), TestCategory(LIFETIME_MANAGEMENT)]
        [DynamicData(nameof(Synchronized_Managers_Data), typeof(Lifetime.Pattern))]
        public virtual void SetValueObjectIsNotAddedToScope(LifetimeManager manager)
        {
            var instance = new object();
            var scope = new LifetimeContainer();

            manager.SetTestValue(instance, scope);

            Assert.AreSame(instance, manager.GetTestValue(scope));
            Assert.IsFalse(scope.Contains(instance));
        }

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod("SetValue(IDisposable) adds to the scope"), TestCategory(LIFETIME_MANAGEMENT)]
        [DynamicData(nameof(Synchronized_Managers_Data), typeof(Lifetime.Pattern))]
        public virtual void SetValueDisposableAddsToScope(LifetimeManager manager)
        {
            if (manager is ExternallyControlledLifetimeManager) return;

            object instance = new TestDisposable();
            var scope = new LifetimeContainer();

            manager.SetTestValue(instance, scope);

            Assert.AreSame(instance, manager.GetTestValue(scope));
            Assert.IsTrue(scope.Contains(instance));
        }
    }
}
