using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime.Manager
{
    public abstract partial class Pattern
    {
        public static ICollection<IDisposable> scope = new List<IDisposable>();

        [DynamicData(nameof(Managers_Data))]
        [DataTestMethod, TestCategory(LIFETIME_MANAGER)]
        public virtual void ToString(LifetimeManager manager)
        {
            var presentation = manager.ToString();
            Assert.IsNotNull(presentation);
        }


        [DynamicData(nameof(Managers_Data))]
        [DataTestMethod, TestCategory(LIFETIME_MANAGER)]
        public virtual void GetHashCode(LifetimeManager manager)
        {
            var code = manager.GetHashCode();
            Assert.AreNotEqual(0, code);
        }


#if !UNITY_V4
        [DynamicData(nameof(Managers_Data))]
        [DataTestMethod, TestCategory(LIFETIME_MANAGER)]
        public virtual void Clone(LifetimeManager manager)
        {
#if UNITY_V5
            var clone = manager.CreateLifetimePolicy();
#else
            var clone = manager.Clone();
#endif

            Assert.IsInstanceOfType(clone, manager.GetType());
            Assert.AreNotSame(manager, clone);
        }
#endif

#if !UNITY_V4 && !UNITY_V5

        [DynamicData(nameof(Managers_Data))]
        [PatternTestMethod("TryGetValue returns NoValue"), TestCategory(LIFETIME_MANAGER)]
        public virtual void TryGetValue(LifetimeManager manager)
        {
            var value = manager.TryGetValue(scope);
            Assert.AreSame(RegistrationManager.NoValue, value);
        }
#endif
    }
}
