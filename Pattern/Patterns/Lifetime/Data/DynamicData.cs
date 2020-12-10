using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Lifetime;
#endif

namespace Lifetime.Manager
{
    public abstract partial class Pattern
    {
        public static IEnumerable<object[]> Managers_Data
        {
            get
            {
                yield return new object[] { new TransientLifetimeManager() };
                yield return new object[] { new PerThreadLifetimeManager() };
                yield return new object[] { new PerResolveLifetimeManager() };
#if !UNITY_V4
                yield return new object[] { new ContainerControlledTransientManager() };
#endif
                yield return new object[] { new ContainerControlledLifetimeManager() };
                yield return new object[] { new HierarchicalLifetimeManager() };
                yield return new object[] { new ExternallyControlledLifetimeManager() };
            }
        }


        public static IEnumerable<object[]> Scope_Lifetime_Data
        {
            get
            {
                #region TransientLifetimeManager

                yield return new object[]
                {
                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new TransientLifetimeManager()),            

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region PerThreadLifetimeManager

                yield return new object[]
                {
                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new PerThreadLifetimeManager()),             

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region PerResolveLifetimeManager

                yield return new object[]
                {
                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new PerResolveLifetimeManager()),            

                    typeof(IView),                              // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                    =>
                    {
                        Assert.AreNotSame(item1, item2);
                        Assert.AreSame(((IView)item1).Presenter.View, item1);
                        Assert.AreSame(((IView)item2).Presenter.View, item2);
                        Assert.AreNotSame(item1, item2);
                    }),

                    (Action<object, object>)((item1, item2)     // FromChildScope
                    =>
                    {
                        Assert.AreNotSame(item1, item2);
                        Assert.AreSame(((IView)item1).Presenter.View, item1);
                        Assert.AreSame(((IView)item2).Presenter.View, item2);
                        Assert.AreNotSame(item1, item2);
                    }),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                    =>
                    {
                        Assert.AreNotSame(item1, item2);
                        Assert.AreSame(((IView)item1).Presenter.View, item1);
                        Assert.AreSame(((IView)item2).Presenter.View, item2);
                        Assert.AreNotSame(item1, item2);
                    }),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                    =>
                    {
                        Assert.AreNotSame(item1, item2);
                        Assert.AreSame(((IView)item1).Presenter.View, item1);
                        Assert.AreSame(((IView)item2).Presenter.View, item2);
                        Assert.AreNotSame(item1, item2);
                    })
                };

                #endregion


                #region ContainerControlledTransientManager
#if !UNITY_V4
                yield return new object[]
                {
                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new ContainerControlledTransientManager()), 

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };
#endif
                #endregion


                #region ContainerControlledLifetimeManager

                yield return new object[]
                {
                    (Func<LifetimeManager>)(() =>
                    new ContainerControlledLifetimeManager()),  // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region HierarchicalLifetimeManager

                yield return new object[]
                {
                    (Func<LifetimeManager>)(() =>
                    new HierarchicalLifetimeManager()),         // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region ExternallyControlledLifetimeManager

                yield return new object[]
                {
                    (Func<LifetimeManager>)(() =>
                    new ExternallyControlledLifetimeManager()), // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
                };

                #endregion
            }
        }
    }
}
