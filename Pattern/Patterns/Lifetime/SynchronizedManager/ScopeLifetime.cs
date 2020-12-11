using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity.Lifetime;
#endif

namespace Lifetime.Synchronization
{
    public abstract partial class Pattern
    {
        [Ignore("TODO: Must be evaluated")]
        [PatternTestMethod("SetValue(object) adds to the scope"), TestCategory(LIFETIME_MANAGEMENT)]
        [DynamicData(nameof(Synchronized_Managers_Data), typeof(Lifetime.Pattern))]
        public virtual void SetObjectAddsToScope(LifetimeManager manager)
        {
            if (manager is ExternallyControlledLifetimeManager) return;

            var instance = new object();
            var scope = new LifetimeContainer();

            manager.SetTestValue(instance, scope);

            Assert.AreSame(instance, manager.GetTestValue(scope));
            Assert.AreEqual(0, scope.Count);
        }


        [Ignore("TODO: Must be evaluated")]
        [PatternTestMethod("SetValue(IDisposable) adds to the scope"), TestCategory(LIFETIME_MANAGEMENT)]
        [DynamicData(nameof(Synchronized_Managers_Data), typeof(Lifetime.Pattern))]
        public virtual void SetDisposableAddsToScope(LifetimeManager manager)
        {
            if (manager is ExternallyControlledLifetimeManager) return;

            var instance = new TestDisposable();
            var scope = new LifetimeContainer();

            manager.SetTestValue(instance, scope);

            Assert.AreSame(instance, manager.GetTestValue(scope));
            Assert.AreEqual(0, scope.Count);
        }
    }
}
