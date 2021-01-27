using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Interception.Tests;
#if UNITY_V4
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
#elif UNITY_V5
using Unity;
using Unity.Interception;
using Unity.Interception.PolicyInjection;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.MatchingRules;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
#else
using Unity;
using Unity.Interception;
using Unity.Interception.PolicyInjection.Pipeline;
#endif

namespace Configuration
{
    public partial class PolicyFixture
    {
        [TestMethod , TestProperty(TEST, INJECTION)]
        public void PolicyWithInjectedInterceptorAndBehavior()
        {
            IMatchingRule rule1 = new AlwaysMatchingRule();
            ICallHandler handler1 = new InvokeCountHandler();

            Container.Configure<Interception>()
                     .AddPolicy(PolicyName)
                        .AddMatchingRule(rule1)
                        .AddCallHandler(handler1);

            Container.RegisterType<Wrappable>(
                new Interceptor<VirtualMethodInterceptor>(),
                new InterceptionBehavior<PolicyInjectionBehavior>());

            Wrappable wrappable1 = Container.Resolve<Wrappable>();
            wrappable1.Method2();

            Assert.AreEqual(1, ((InvokeCountHandler)handler1).Count);
        }

        [TestMethod, TestProperty(TEST, INJECTION)]
        public void PolicyWithInjectedInterceptor()
        {
            IMatchingRule rule1 = new AlwaysMatchingRule();
            ICallHandler handler1 = new InvokeCountHandler();

            Container.Configure<Interception>()
                     .AddPolicy(PolicyName)
                        .AddMatchingRule(rule1)
                        .AddCallHandler(handler1);

            Container.RegisterType<Wrappable>(
                new Interceptor<VirtualMethodInterceptor>());

            Wrappable wrappable1 = Container.Resolve<Wrappable>();
            wrappable1.Method2();

            Assert.AreEqual(0, ((InvokeCountHandler)handler1).Count);
        }


        [TestMethod, TestProperty(TEST, INJECTION)]
        public void PolicyWithInjectedBehavior()
        {
            IMatchingRule rule1 = new AlwaysMatchingRule();
            ICallHandler handler1 = new InvokeCountHandler();

            Container.Configure<Interception>()
                     .AddPolicy(PolicyName)
                        .AddMatchingRule(rule1)
                        .AddCallHandler(handler1);

            Container.RegisterType<Wrappable>(
                new InterceptionBehavior<PolicyInjectionBehavior>());

            Wrappable wrappable1 = Container.Resolve<Wrappable>();
            wrappable1.Method2();

            Assert.AreEqual(0, ((InvokeCountHandler)handler1).Count);
        }
    }
}
