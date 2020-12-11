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
        #region Fields

        protected object Item1;
        protected object Item2;
        protected Type TargetType;

        #endregion


        #region Implementation

        protected virtual bool ArrangeTest(Func<LifetimeManager> factory, Type type = null)
        {
            var manager = factory();
#if UNITY_V4
            Container.RegisterType(typeof(IService), typeof(Service), manager)
                     .RegisterType(typeof(MockLogger), factory());
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(factory());
#else
            Container.RegisterType(typeof(IService), typeof(Service), (ITypeLifetimeManager)manager)
                     .RegisterType(typeof(MockLogger), (ITypeLifetimeManager)factory());
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>((ITypeLifetimeManager)factory());
#endif
            TargetType = type ?? typeof(IService);

            return manager is PerResolveLifetimeManager 
                ? true : false;
        }

        #endregion


        #region Test Types

        public interface IPresenter
        {
            IView View { get; }
        }

        public class MockPresenter : IPresenter
        {
            public IView View { get; set; }

            public MockPresenter(IView view)
            {
                View = view;
            }
        }

        public interface IView
        {
            IPresenter Presenter { get; set; }
        }

        public class View : IView
        {
            [Dependency]
            public IPresenter Presenter { get; set; }
        }

        #endregion


        #region Test Data

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


        public static IEnumerable<object[]> Two_Scopes_Data
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
