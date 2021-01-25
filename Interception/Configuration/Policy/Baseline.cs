using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

        [TestMethod("AttributeDrivenPolicy configured by default"), TestProperty(TEST, "Defaults")]
        public void Baseline()
        {
            // empty
            var policies = Container.Resolve<InjectionPolicy[]>();

            Assert.AreEqual(1, policies.Length);
            Assert.IsInstanceOfType(policies[0], typeof(AttributeDrivenPolicy));
        }


        [TestMethod("Empty Rule"), TestProperty(TEST, EMPTY)]
        public void CanSetUpEmptyRule()
        {
            // empty
            Container.Configure<Interception>()
                     .AddPolicy(PolicyName);

            var policies = Container.Resolve<InjectionPolicy[]>();

            Assert.AreEqual(2, policies.Length);
            Assert.IsInstanceOfType(policies[0], typeof(AttributeDrivenPolicy));
            Assert.IsInstanceOfType(policies[1], typeof(RuleDrivenPolicy));
            Assert.AreEqual(PolicyName, policies[1].Name);
        }


        [TestMethod("Multiple Empty Rules"), TestProperty(TEST, EMPTY)]
        public void CanSetUpSeveralEmptyRules()
        {
            // empty
            Container
                .Configure<Interception>()
                    .AddPolicy(PolicyName).Interception
                    .AddPolicy("policy2");

            List<InjectionPolicy> policies
                = new List<InjectionPolicy>(Container.ResolveAll<InjectionPolicy>());

            Assert.AreEqual(3, policies.Count);
            Assert.IsInstanceOfType(policies[0], typeof(AttributeDrivenPolicy));
            Assert.IsInstanceOfType(policies[1], typeof(RuleDrivenPolicy));
            Assert.AreEqual(PolicyName, policies[1].Name);
            Assert.IsInstanceOfType(policies[2], typeof(RuleDrivenPolicy));
            Assert.AreEqual("policy2", policies[2].Name);
        }
    }
}
