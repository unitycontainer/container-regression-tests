using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression.Container;
#if UNITY_V4
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.Unity;
#elif UNITY_V5
using Unity.Builder;
using Unity;
#else
using Unity.Extension;
#endif

namespace Container
{
    public partial class Extending
    {
#if UNITY_V4 || UNITY_V5
        [TestMethod]
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

        [TestMethod]
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
#endif
    }
}
