using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
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

        protected virtual void ArrangeTest(LifetimeManager manager, Type type = null)
        {
#if UNITY_V4
            Container.RegisterType(typeof(IService), typeof(Service), manager)
                     .RegisterType(typeof(MockLogger), manager);
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(manager);
#else
            Container.RegisterType(typeof(IService), typeof(Service), (ITypeLifetimeManager)manager)
                     .RegisterType(typeof(MockLogger), (ITypeLifetimeManager)manager);
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>((ITypeLifetimeManager)manager);
#endif
            TargetType = type ?? typeof(IService);
        }

        #endregion


        #region Test Data

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
    }
}
