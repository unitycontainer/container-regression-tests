using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression.Container;
using System.Collections;
using System.Linq;
using System;
using Unity.Builder;
#if UNITY_V4
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
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
                .AddExtension(new SpyExtension(spy, UnityBuildStage.PreCreation))
                .Configure<SpyExtension>();

            Assert.IsNotNull(extension);
            Assert.IsNotNull(extension.Container);
            Assert.IsNotNull(extension.ExtensionContext);
        }

        [TestMethod("Can Enumerate Strategies"), TestProperty(TESTING, nameof(BuilderStrategy))]
        [Obsolete]
        public void CanEnumerateStrategies()
        {
            SpyStrategy spy = new SpyStrategy();

            var extension = new UnityContainer()
                .AddExtension(new SpyExtension(spy, UnityBuildStage.PreCreation))
                .Configure<SpyExtension>();

            var enumerable = AsEnumerable(extension.ExtensionContext.Strategies);

            Assert.IsTrue(enumerable is IEnumerable);
        }
    }
}
