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

namespace Lifetime
{
    public abstract partial class Pattern
    {
        private ICollection<IDisposable> _scope = new List<IDisposable>();



        [PatternTestMethod("TryGetValue(...) does not block"), TestCategory(LIFETIME_MANAGER)]
        [DynamicData(nameof(Lifetime_Managers_Data))]
        public void TryGetValueDoesNotBlock(LifetimeManager manager)
        {
            var value = manager.TryGetValue(_scope);
            object other = null;

            // Act
            Thread thread = new Thread(new ParameterizedThreadStart((c) => 
            {
                other = manager.TryGetValue(_scope);
            }));

            thread.Start("1");
            thread.Join();

            Assert.AreSame(value, other);
        }


        [PatternTestMethod("LifetimeManager.GetValue(...) does not block"), TestCategory(SYNCHRONIZED_MANAGER)]
        [DynamicData(nameof(Lifetime_Managers_Data))]
        public virtual void GetValueBlocks(LifetimeManager manager)
        {
            if (manager is SynchronizedLifetimeManager) return;

            var value = manager.GetValue(_scope);
            object other = null;

            // Act
            Thread thread = new Thread(new ParameterizedThreadStart((c) =>
            {
                other = manager.GetValue(_scope);
            }));

            thread.Start("1");
            thread.Join();

            Assert.AreSame(value, other);
        }
    }
}
