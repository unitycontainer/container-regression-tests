using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression.Container;
#if UNITY_V4
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Builder;
using Unity.Strategies;
#endif

namespace Container
{
    public partial class Extensions
    {
        [TestMethod("Can get Extension Context"), TestProperty(TESTING, nameof(BuilderStrategy))]
        public void CanGetExtensionContext()
        {
            SpyStrategy spy = new SpyStrategy();

            var extension = new UnityContainer()
                .AddExtension(new SpyExtension(spy, (int)UnityBuildStage.PreCreation))
                .Configure<SpyExtension>();

            Assert.IsNotNull(extension);
            Assert.IsNotNull(extension.Container);
            Assert.IsNotNull(extension.ExtensionContext);
        }
    }
}
