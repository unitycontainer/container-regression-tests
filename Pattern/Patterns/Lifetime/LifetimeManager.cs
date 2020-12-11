using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System.Threading;
using Unity.Lifetime;

namespace Lifetime
{
    public abstract partial class Pattern
    {
        [PatternTestMethod("TryGetValue(...) does not block"), TestCategory(LIFETIME_MANAGER)]
        [DynamicData(nameof(Lifetime_Managers_Data))]
        public void TryGetValueDoesNotBlock(LifetimeManager manager)
        {
            var scope = new LifetimeContainer();
            var value = manager.TryGetValue(scope);
            object other = null;

            // Act
            Thread thread = new Thread(new ParameterizedThreadStart((c) => 
            {
                other = manager.TryGetValue(scope);
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

            var scope = new LifetimeContainer();
            var value = manager.GetValue(scope);
            object other = null;

            // Act
            Thread thread = new Thread(new ParameterizedThreadStart((c) =>
            {
                other = manager.GetValue(scope);
            }));

            thread.Start("1");
            thread.Join();

            Assert.AreSame(value, other);
        }
    }
}
