using Regression;
using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime
{
    public abstract partial class Pattern : FixtureBase
    {
        #region Constants

        protected const string SAME_SCOPE  = "Same Scope";
        protected const string CHILD_SCOPE = "Child Scope";
        protected const string SIBLING_SCOPES  = "Sibling Scopes";
        protected const string LIFETIME_MANAGER = "Manager";
        protected const string SYNCHRONIZED_MANAGER = "Synchronization";
        protected const string LIFETIME_MANAGEMENT = "Scope";

        #endregion


        #region Fields

        protected object Item1;
        protected object Item2;
        protected Type TargetType;

        #endregion


        #region Implementation

        protected virtual bool ArrangeTest(Func<LifetimeManager> factory, Type type, IUnityContainer child = null)
        {
            var manager = factory();
#if UNITY_V4
            Container.RegisterType(typeof(IService), typeof(Service), manager)
                     .RegisterType(typeof(MockLogger), factory())
                     .RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(factory());
#else
            Container.RegisterType(typeof(IService), typeof(Service), (ITypeLifetimeManager)manager)
                     .RegisterType(typeof(MockLogger), (ITypeLifetimeManager)factory())
                     .RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>((ITypeLifetimeManager)factory());
#endif
            TargetType = type;

            if (child is not null)
            {
#if UNITY_V4
                child.RegisterType(typeof(IService), typeof(Service), manager)
                     .RegisterType(typeof(MockLogger), factory())
                     .RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(factory());
#else
                child.RegisterType(typeof(IService), typeof(Service), (ITypeLifetimeManager)manager)
                     .RegisterType(typeof(MockLogger), (ITypeLifetimeManager)factory())
                     .RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>((ITypeLifetimeManager)factory());
#endif
            }

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

        public static IEnumerable<object[]> Lifetime_Managers_Data
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


        public static IEnumerable<object[]> Synchronized_Managers_Data
            => Lifetime_Managers_Data.Where(set => set[0] is SynchronizedLifetimeManager);

        #endregion
    }
}
