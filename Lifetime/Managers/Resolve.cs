using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime
{
    public partial class Managers
    {
        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(PerResolveLifetimeManager))]
        public void PerResolve_CanBeConfigured()
        {
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(TypeLifetime.PerResolve);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(PerResolveLifetimeManager))]
        public void PerResolve_ViewIsReusedAcrossGraph()
        {
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(TypeLifetime.PerResolve);

            var view = Container.Resolve<IView>();

            var realPresenter = (MockPresenter)view.Presenter;
            Assert.AreSame(view, realPresenter.View);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(PerResolveLifetimeManager))]
        public void PerResolve_ViewsAreDifferentInDifferentResolveCalls()
        {
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(TypeLifetime.PerResolve);

            var view1 = Container.Resolve<IView>();
            var view2 = Container.Resolve<IView>();

            Assert.AreNotSame(view1, view2);
        }

        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(PerResolveLifetimeManager))]
        public void PerResolve_FromMultipleThreads()
        {
            Container.RegisterType<IPresenter, MockPresenter>()
                     .RegisterType<IView, View>(TypeLifetime.PerResolve);

            object result1 = null;
            object result2 = null;

            Thread thread1 = new Thread(delegate ()
            {
                result1 = Container.Resolve<IView>();
            });

            Thread thread2 = new Thread(delegate ()
            {
                result2 = Container.Resolve<IView>();
            });

            thread1.Name = "1";
            thread2.Name = "2";

            thread1.Start();
            thread2.Start();

            thread2.Join();
            thread1.Join();

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreNotSame(result1, result2);
        }


        [TestMethod, TestProperty(LIFETIME_MANAGER, nameof(PerResolveLifetimeManager))]
        public void PerResolve_LifetimeIsHonoredWhenUsingFactory()
        {
            Container.RegisterFactory<SomeService>(c => new SomeService(), FactoryLifetime.PerResolve);

            var rootService = Container.Resolve<AService>();
            Assert.AreSame(rootService.SomeService, rootService.OtherService.SomeService);
        }

    }
}
