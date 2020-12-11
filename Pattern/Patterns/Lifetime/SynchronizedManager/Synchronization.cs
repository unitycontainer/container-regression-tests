using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
using System.Threading;
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
        #region Fields

        private ICollection<IDisposable> _scope = new List<IDisposable>();
        
        #endregion


        [PatternTestMethod("SynchronizedManager.GetValue(...) blocks")]
        [DynamicData(nameof(Lifetime_Managers_Data), typeof(Lifetime.Pattern))]
        public override void GetValueBlocks(LifetimeManager manager)
        {
            if (manager is not SynchronizedLifetimeManager)
            { 
                base.GetValueBlocks(manager);
                return;
            }

            var value = manager.GetValue(_scope);

            // Act
            Thread thread = new Thread(new ParameterizedThreadStart((c) =>
            {
                Assert.ThrowsException<TimeoutException>(() => _ = manager.GetValue(_scope));
            }));

            SynchronizedLifetimeManager.ResolveTimeout = 10;
            thread.Start("1");
            thread.Join();
            SynchronizedLifetimeManager.ResolveTimeout = Timeout.Infinite;
        }


        [PatternTestMethod("SetValue(...) releases a blocks"), TestCategory(SYNCHRONIZED_MANAGER)]
        [DynamicData(nameof(Synchronized_Managers_Data), typeof(Lifetime.Pattern))]
        public void SetValueReleasesBlock(SynchronizedLifetimeManager manager)
        {
            object other = null;
            var instance = new object();
            var semaphore = new ManualResetEventSlim();
            var NoValue = manager.GetValue(_scope);

            // Act
            Thread thread = new Thread(new ParameterizedThreadStart((c) =>
            {
                semaphore.Set();
                other = manager.GetValue(_scope);
            }));
            
            // Wait for thread to reach semaphore and some
            thread.Start("1");
            semaphore.Wait();
            Thread.Sleep(5);
            
            // Set value and wait
            manager.SetValue(instance, _scope);
            thread.Join();

            // Validate
            Assert.AreSame(instance, other);
            Assert.AreNotSame(NoValue, other);
        }


        [PatternTestMethod("Recover() releases a blocks"), TestCategory(SYNCHRONIZED_MANAGER)]
        [DynamicData(nameof(Synchronized_Managers_Data), typeof(Lifetime.Pattern))]
        public void RecoverReleasesBlock(SynchronizedLifetimeManager manager)
        {
            var semaphore = new ManualResetEventSlim();
            var NoValue = manager.GetValue(_scope);
            object other = null;

            // Act
            Thread thread = new Thread(new ParameterizedThreadStart((c) =>
            {
                semaphore.Set();
                other = manager.GetValue(_scope);
            }));

            // Wait for thread to reach semaphore and some
            thread.Start("1");
            semaphore.Wait();
            Thread.Sleep(5);

            // Set value and wait
            manager.Recover();
            thread.Join();

            // Validate
            Assert.AreSame(NoValue, other);
        }
    }
}
