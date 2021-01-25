using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity.InterceptionExtension;
#elif UNITY_V5
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors;
using Unity.Interception.Interceptors.InstanceInterceptors;
using Unity.Interception.Interceptors.TypeInterceptors;
using Unity.Interception.PolicyInjection.Pipeline;
#else
using Unity;
using Unity.Interception;
using Unity.Interception.PolicyInjection.Pipeline;
#endif

namespace Configuration
{
    public partial class PolicyFixture
    {
        [TestMethod("Add Rule By Name (missing)"), TestProperty(TEST, HANDLERS)]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void AddHandlerByNameMissing()
        {
            Container.Configure<Interception>()
                     .AddPolicy(PolicyName)
                        .AddCallHandler(Name);

            _ = Container.Resolve<InjectionPolicy>(PolicyName);
        }


        [TestMethod("Add Rule By Name"), TestProperty(TEST, HANDLERS)]
        public void AddHandlerByName()
        {
            Container.RegisterInstance(Name, handler)
                     .Configure<Interception>()
                        .AddPolicy(PolicyName)
                            .AddCallHandler(Name);

            // empty
            var policy = Container.Resolve<InjectionPolicy>(PolicyName);

            Assert.IsNotNull(policy);
            Assert.IsInstanceOfType(policy, typeof(RuleDrivenPolicy));
            Assert.AreEqual(PolicyName, policy.Name);
            Assert.IsFalse(policy.Matches(info));
        }


        [TestMethod("Add Rule By Instance"), TestProperty(TEST, HANDLERS)]
        public void AddHandlerByInstance()
        {
            Container.Configure<Interception>()
                        .AddPolicy(PolicyName)
                            .AddCallHandler(handler);

            // empty
            var policy = Container.Resolve<InjectionPolicy>(PolicyName);

            Assert.IsNotNull(policy);
            Assert.IsInstanceOfType(policy, typeof(RuleDrivenPolicy));
            Assert.AreEqual(PolicyName, policy.Name);
            Assert.IsFalse(policy.Matches(info));
        }
    }
}
