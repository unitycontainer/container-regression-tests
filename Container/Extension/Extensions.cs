using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression.Container;
using Regression;
using Unity.Builder;
#if UNITY_V4
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity.Strategies;
using Unity;
#endif

namespace Container
{
    public partial class Extensions
    {
        [PatternTestMethod(NAME_PATTERN), TestProperty(TESTING, nameof(BuilderStrategy))]
        public void ExtensionCanAddStrategy_PreCreation()
        {
            SpyStrategy spy = new SpyStrategy();
            SpyExtension extension = new SpyExtension(spy, UnityBuildStage.PreCreation);

            IUnityContainer container = new UnityContainer()
                .AddExtension(extension);

            object result = container.Resolve<object>();
            Assert.IsTrue(spy.BuildUpWasCalled);
            Assert.AreSame(result, spy.Existing);
        }

        [PatternTestMethod(NAME_PATTERN), TestProperty(TESTING, nameof(BuilderStrategy))]
        public void ExtensionCanAddStrategy_PostInitialization()
        {
            SpyStrategy spy = new SpyStrategy();
            SpyExtension extension = new SpyExtension(spy, UnityBuildStage.PostInitialization);

            IUnityContainer container = new UnityContainer()
                .AddExtension(extension);

            object result = container.Resolve<object>();
            Assert.IsTrue(spy.BuildUpWasCalled);
            Assert.AreSame(result, spy.Existing);
        }


        [TestMethod("Can Add Default Policy"), TestProperty(TESTING, POLICY)]
        public void ExtensionCanAddDefaultPolicy()
        {
            SpyStrategy spy = new SpyStrategy();
            SpyPolicy spyPolicy = new SpyPolicy();

            SpyExtension extension =
                new SpyExtension(spy, UnityBuildStage.PreCreation, spyPolicy, typeof(SpyPolicy));

            IUnityContainer container = new UnityContainer()
                .AddExtension(extension);

            container.Resolve<object>();

            Assert.IsTrue(spyPolicy.WasSpiedOn);
        }
    }
}
