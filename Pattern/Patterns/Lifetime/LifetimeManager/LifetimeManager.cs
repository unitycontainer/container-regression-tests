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
        private static ICollection<IDisposable> scope = new List<IDisposable>();

        [DynamicData(nameof(Lifetime_Managers_Data), typeof(Lifetime.Pattern))]
        [DataTestMethod, TestCategory(LIFETIME_MANAGER)]
        public virtual void ToString(LifetimeManager manager)
        {
            var presentation = manager.ToString();
            Assert.IsNotNull(presentation);
        }


        [DynamicData(nameof(Lifetime_Managers_Data), typeof(Lifetime.Pattern))]
        [DataTestMethod, TestCategory(LIFETIME_MANAGER)]
        public virtual void GetHashCode(LifetimeManager manager)
        {
            var code = manager.GetHashCode();
            Assert.AreNotEqual(0, code);
        }


#if !UNITY_V4
        [DynamicData(nameof(Lifetime_Managers_Data), typeof(Lifetime.Pattern))]
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

        [DynamicData(nameof(Lifetime_Managers_Data), typeof(Lifetime.Pattern))]
        [PatternTestMethod("TryGetValue returns NoValue"), TestCategory(LIFETIME_MANAGER)]
        public virtual void TryGetValue(LifetimeManager manager)
        {
            var value = manager.TryGetValue(scope);
            Assert.AreSame(RegistrationManager.NoValue, value);
        }
#endif

        [DynamicData(nameof(Set_Value_Data))]
        [PatternTestMethod("GetValue() same as saved by SetValue()"), TestCategory(LIFETIME_MANAGER)]
        public virtual void SetGetValue(LifetimeManager manager, Action<object, object> assert)
        {
            manager.SetValue(this, scope);
            assert(this, manager.GetValue(scope));
        }
    }
}
