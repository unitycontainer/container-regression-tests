using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Regression.Lifetime
{
    public abstract partial class Pattern : ManagerBase
    {
        #region Fields

        protected Type TargetType;

        #endregion

        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

#if UNITY_V4
            Container.RegisterType(typeof(IService), typeof(Service), (ITypeLifetimeManager)LifetimeManager)
                     .RegisterType(typeof(MockLogger), LifetimeManager);
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(LifetimeManager);
#else
            Container.RegisterType(typeof(IService), typeof(Service), (ITypeLifetimeManager)LifetimeManager)
                     .RegisterType(typeof(MockLogger), (ITypeLifetimeManager)LifetimeManager);
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>((ITypeLifetimeManager)LifetimeManager);
#endif
            TargetType = typeof(IService);
        }

        #endregion


        #region Validators

        public abstract void FromSameScope(object item1, object item2);
        public abstract void FromChildScope(object item1, object item2);

        public abstract void FromSameScopeDifferentThreads(object item1, object item2);
        public abstract void FromChildScopeDifferentThreads(object item1, object item2);

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
