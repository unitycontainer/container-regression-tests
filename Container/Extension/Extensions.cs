﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression.Container;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity.Strategies;
using Unity.Builder;
using Unity;
#endif

namespace Container
{
    public partial class Extensions
    {
        [Ignore("TODO: Reenable")]
        [PatternTestMethod(NAME_PATTERN), TestProperty(TESTING, "Builder Strategy")]
        public void ExtensionCanAddStrategy_PreCreation()
        {
            SpyStrategy spy = new SpyStrategy();
            SpyExtension extension = new SpyExtension(spy, (int)UnityBuildStage.PreCreation);

            IUnityContainer container = new UnityContainer()
                .AddExtension(extension);

            object result = container.Resolve<object>();
            Assert.IsTrue(spy.BuildUpWasCalled);
            Assert.AreSame(result, spy.Existing);
        }

        [Ignore("BEHAVIOR_V8")]
        [PatternTestMethod(NAME_PATTERN), TestProperty(TESTING, "Builder Strategy")]
        public void ExtensionCanAddStrategy_PostInitialization()
        {
            SpyStrategy spy = new SpyStrategy();
            SpyExtension extension = new SpyExtension(spy, (int)UnityBuildStage.PostInitialization);

            IUnityContainer container = new UnityContainer()
                .AddExtension(extension);

            object result = container.Resolve<object>();
            Assert.IsTrue(spy.BuildUpWasCalled);
            Assert.AreSame(result, spy.Existing);
        }


        [Ignore("BEHAVIOR_V8")]
        [TestMethod("Can Add Default Policy"), TestProperty(TESTING, POLICY)]
        public void ExtensionCanAddDefaultPolicy()
        {
            SpyStrategy spy = new SpyStrategy();
            SpyPolicy spyPolicy = new SpyPolicy();

            SpyExtension extension =
                new SpyExtension(spy, (int)UnityBuildStage.PreCreation, spyPolicy, typeof(SpyPolicy));

            IUnityContainer container = new UnityContainer()
                .AddExtension(extension);

            container.Resolve<object>();

            Assert.IsTrue(spyPolicy.WasSpiedOn);
        }
    }
}
