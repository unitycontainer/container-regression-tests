using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime.Manager
{
    public abstract partial class Pattern : Lifetime.Pattern
    {
        #region Test Data

        public static IEnumerable<object[]> Set_Value_Data
        {
            get
            {
                #region TransientLifetimeManager

                yield return new object[]
                {
                    new TransientLifetimeManager(),             // Manager

                    (Action<object, object>)((item1, item2)     // Assert
                        => Assert.AreNotSame(item1, item2))
                };

                #endregion


                #region PerThreadLifetimeManager

                yield return new object[]
                {
                    new PerThreadLifetimeManager(),             // Manager

                    (Action<object, object>)((item1, item2)     // Assert
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region PerResolveLifetimeManager

                yield return new object[]
                {
                    new PerResolveLifetimeManager(),            // Manager

                    (Action<object, object>)((item1, item2)     // Assert
                        => Assert.AreNotSame(item1, item2))
                };

                #endregion


                #region ContainerControlledTransientManager
#if !UNITY_V4
                yield return new object[]
                {
                    new ContainerControlledTransientManager(),  // Manager

                    (Action<object, object>)((item1, item2)     // Assert
                        => Assert.AreNotSame(item1, item2)),
                };
#endif
                #endregion


                #region ContainerControlledLifetimeManager

                yield return new object[]
                {
                    new ContainerControlledLifetimeManager(),  // Manager

                    (Action<object, object>)((item1, item2)    // Assert
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region HierarchicalLifetimeManager

                yield return new object[]
                {
                    new HierarchicalLifetimeManager(),         // Manager

                    (Action<object, object>)((item1, item2)    // Assert
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region ExternallyControlledLifetimeManager

                yield return new object[]
                {
                    new ExternallyControlledLifetimeManager(), // Manager

                    (Action<object, object>)((item1, item2)    // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2))
                };

                #endregion
            }
        }


        public static IEnumerable<object[]> Same_Scope_Data
        {
            get
            {
                #region TransientLifetimeManager

                yield return new object[]
                {
                    typeof(TransientLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new TransientLifetimeManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2))
                };

                #endregion


                #region PerThreadLifetimeManager

                yield return new object[]
                {
                    typeof(PerThreadLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new PerThreadLifetimeManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region PerResolveLifetimeManager

                yield return new object[]
                {
                    typeof(PerResolveLifetimeManager).Name,     // Name

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

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                    =>
                    {
                        Assert.AreNotSame(item1, item2);
                        Assert.AreSame(((IView)item1).Presenter.View, item1);
                        Assert.AreSame(((IView)item2).Presenter.View, item2);
                        Assert.AreNotSame(item1, item2);
                    }),
                };

                #endregion


                #region ContainerControlledTransientManager
#if !UNITY_V4
                yield return new object[]
                {
                    typeof(ContainerControlledTransientManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new ContainerControlledTransientManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };
#endif
                #endregion


                #region ContainerControlledLifetimeManager

                yield return new object[]
                {
                    typeof(ContainerControlledLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new ContainerControlledLifetimeManager()),  // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region HierarchicalLifetimeManager

                yield return new object[]
                {
                    typeof(HierarchicalLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new HierarchicalLifetimeManager()),         // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region ExternallyControlledLifetimeManager

                yield return new object[]
                {
                    typeof(ExternallyControlledLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new ExternallyControlledLifetimeManager()), // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
};

                #endregion
            }
        }


        public static IEnumerable<object[]> Child_Scope_Data
        {
            get
            {
                #region TransientLifetimeManager

                yield return new object[]
                {
                    typeof(TransientLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new TransientLifetimeManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region PerThreadLifetimeManager

                yield return new object[]
                {
                    typeof(PerThreadLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new PerThreadLifetimeManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region PerResolveLifetimeManager

                yield return new object[]
                {
                    typeof(PerResolveLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new PerResolveLifetimeManager()),

                    typeof(IView),                              // Target Type

                    (Action<object, object>)((item1, item2)     // FromChildScope
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
                    }),
                };

                #endregion


                #region ContainerControlledTransientManager
#if !UNITY_V4
                yield return new object[]
                {
                    typeof(ContainerControlledTransientManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new ContainerControlledTransientManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };
#endif
                #endregion


                #region ContainerControlledLifetimeManager

                yield return new object[]
                {
                    typeof(ContainerControlledLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new ContainerControlledLifetimeManager()),  // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region HierarchicalLifetimeManager

                yield return new object[]
                {
                    typeof(HierarchicalLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new HierarchicalLifetimeManager()),         // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region ExternallyControlledLifetimeManager

                yield return new object[]
                {
                    typeof(ExternallyControlledLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new ExternallyControlledLifetimeManager()), // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromChildScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromChildScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
};
                #endregion
            }
        }


        public static IEnumerable<object[]> Sibling_Scopes_Data
        {
            get
            {
                #region TransientLifetimeManager

                yield return new object[]
                {
                    typeof(TransientLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new TransientLifetimeManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2))
                };

                #endregion


                #region PerThreadLifetimeManager

                yield return new object[]
                {
                    typeof(PerThreadLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new PerThreadLifetimeManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region PerResolveLifetimeManager

                yield return new object[]
                {
                    typeof(PerResolveLifetimeManager).Name,     // Name

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

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                    =>
                    {
                        Assert.AreNotSame(item1, item2);
                        Assert.AreSame(((IView)item1).Presenter.View, item1);
                        Assert.AreSame(((IView)item2).Presenter.View, item2);
                        Assert.AreNotSame(item1, item2);
                    }),
                };

                #endregion


                #region ContainerControlledTransientManager
#if !UNITY_V4
                yield return new object[]
                {
                    typeof(ContainerControlledTransientManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>               // Manager factory
                    new ContainerControlledTransientManager()),

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };
#endif
                #endregion


                #region ContainerControlledLifetimeManager

                yield return new object[]
                {
                    typeof(ContainerControlledLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new ContainerControlledLifetimeManager()),  // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
                };

                #endregion


                #region HierarchicalLifetimeManager

                yield return new object[]
                {
                    typeof(HierarchicalLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new HierarchicalLifetimeManager()),         // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreNotSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreNotSame(item1, item2)),
                };

                #endregion


                #region ExternallyControlledLifetimeManager

                yield return new object[]
                {
                    typeof(ExternallyControlledLifetimeManager).Name,     // Name

                    (Func<LifetimeManager>)(() =>
                    new ExternallyControlledLifetimeManager()), // Manager factory

                    typeof(IService),                           // Target Type

                    (Action<object, object>)((item1, item2)     // FromSameScope
                        => Assert.AreSame(item1, item2)),

                    (Action<object, object>)((item1, item2)     // FromSameScopeDifferentThreads
                        => Assert.AreSame(item1, item2)),
};

                #endregion
            }
        }

        #endregion
    }
}
