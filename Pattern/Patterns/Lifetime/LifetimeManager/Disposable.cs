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
        [PatternTestMethod("SetValue(...) adds IDisposable to scope"), TestCategory(LIFETIME_MANAGER)]
        [DynamicData(nameof(Lifetime_Disposable_Data))]
        public void SetValueAddsLifetime(string name, Func<LifetimeManager> factory, bool isDisposable)
        {
            // Arrange
            var scope = new List<IDisposable>();
            object instance = new object();
            object disposable = new TestDisposable();

            // Act
            var manager = factory();
            manager.SetValue(instance, scope);

            // Validate object does not add IDIsposable
            var expected = manager is HierarchicalLifetimeManager ? 1 : 0;
            Assert.AreEqual(expected, scope.Count);
            scope.Clear();

            manager = factory();
            manager.SetValue(disposable, scope);

            // Validate object does add IDIsposable
            expected = isDisposable ? 1 : 0;
            Assert.AreEqual(expected, scope.Count);
        }
    }
}
