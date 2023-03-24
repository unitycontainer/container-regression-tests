﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression.Container;
using System.Collections;
using System.Linq;
using System;
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

        [TestMethod("Can Add Strategy"), TestProperty(TESTING, nameof(BuilderStrategy))]
        [Obsolete]
        public void CanAddStrategy()
        {
            SpyStrategy spy = new SpyStrategy();

            var extension = new UnityContainer()
                .AddExtension(new SpyExtension(spy, UnityBuildStage.PreCreation))
                .Configure<SpyExtension>();

            var strategies = extension.ExtensionContext.Strategies.Values.ToArray();

            Assert.IsTrue(strategies.Contains(spy));
        }

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [TestMethod("Can Add Strategy Twice"), TestProperty(TESTING, nameof(BuilderStrategy))]
        [Obsolete]
        [ExpectedException(typeof(ArgumentException))]
        public void CanAddStrategyTwice()
        {
            SpyStrategy spy = new SpyStrategy();

            var extension = new UnityContainer()
                .AddExtension(new SpyExtension(spy, UnityBuildStage.PreCreation))
                .Configure<SpyExtension>();

            var before = extension.ExtensionContext.Strategies.Values.ToArray();

            Assert.IsTrue(before.Contains(spy));

            extension.ExtensionContext.Strategies.Add(spy, UnityBuildStage.PreCreation);
            
            var after = extension.ExtensionContext.Strategies.Values.ToArray();

            Assert.AreNotEqual(before.Length, after.Length);
        }
    }
}
