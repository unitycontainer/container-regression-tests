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
        [TestMethod("Rule By Name (missing)"), TestProperty(TEST, RULES)]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void AddRuleByNameMissing()
        {
            Container.Configure<Interception>()
                     .AddPolicy(PolicyName)
                        .AddMatchingRule(Name);

            _ = Container.Resolve<InjectionPolicy>(PolicyName);
        }


        [TestMethod("Rule By Name"), TestProperty(TEST, RULES)]
        public void AddRuleByName()
        {
            Container.RegisterInstance(Name, rule)
                     .Configure<Interception>()
                        .AddPolicy(PolicyName)
                            .AddMatchingRule(Name);

            // empty
            var policy = Container.Resolve<InjectionPolicy>(PolicyName);

            Assert.IsNotNull(policy);
            Assert.IsInstanceOfType(policy, typeof(RuleDrivenPolicy));
            Assert.AreEqual(PolicyName, policy.Name);
            Assert.IsTrue(policy.Matches(info));
        }


        [TestMethod("Rule By Instance"), TestProperty(TEST, RULES)]
        public void AddRuleByInstance()
        {
            Container.Configure<Interception>()
                        .AddPolicy(PolicyName)
                            .AddMatchingRule(rule);
            // empty
            var policy = Container.Resolve<InjectionPolicy>(PolicyName);

            Assert.IsNotNull(policy);
            Assert.IsInstanceOfType(policy, typeof(RuleDrivenPolicy));
            Assert.AreEqual(PolicyName, policy.Name);
            Assert.IsTrue(policy.Matches(info));
        }
    }
}
