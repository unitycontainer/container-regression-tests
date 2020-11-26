﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Resolution
{
    public partial class Arrays
    {
        [TestMethod]
        public void CanResolveArrayForConstructorParameter()
        {
            IService o1 = new Service();
            IService o2 = new OtherService();

            Container.RegisterInstance<IService>("o1", o1)
                     .RegisterInstance<IService>("o2", o2);

            var resolved = Container.Resolve<TypeWithArrayParameter>();

            Assert.IsNotNull(resolved.Loggers);
            Assert.AreEqual(2, resolved.Loggers.Length);
            Assert.AreSame(o1, resolved.Loggers[0]);
            Assert.AreSame(o2, resolved.Loggers[1]);
        }

        [TestMethod]
        public void CanResolveArrayForProperty()
        {
            IService o1 = new Service();
            IService o2 = new OtherService();

            Container.RegisterInstance<IService>("o1", o1)
                     .RegisterInstance<IService>("o2", o2);

            var resolved = Container.Resolve<TypeWithArrayProperty>();

            Assert.IsNotNull(resolved.Loggers);
            Assert.AreEqual(2, resolved.Loggers.Length);
            Assert.AreSame(o1, resolved.Loggers[0]);
            Assert.AreSame(o2, resolved.Loggers[1]);
        }

        [TestMethod]
        public void CanResolveArrayForConstructorParameterOnClosedGenericType()
        {
            IService o1 = new Service();
            IService o2 = new OtherService();

            Container.RegisterInstance<IService>("o1", o1)
                     .RegisterInstance<IService>("o2", o2);

            var resolved = Container.Resolve<GenericTypeWithArrayParameter<IService>>();

            Assert.IsNotNull(resolved.Values);
            Assert.AreEqual(2, resolved.Values.Length);
            Assert.AreSame(o1, resolved.Values[0]);
            Assert.AreSame(o2, resolved.Values[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void BindingDependencyArrayToArrayParameterWithRankOverOneThrows()
        {
            Container.Resolve<TypeWithArrayConstructorParameterOfRankTwo>();
        }
    }
}
