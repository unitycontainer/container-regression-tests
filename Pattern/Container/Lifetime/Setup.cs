using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Container
{
    [TestClass]
    public partial class Lifetime
    {
        #region Fields

        protected IUnityContainer Container;

        #endregion

        #region Scaffolding

        [TestInitialize]
        public virtual void TestInitialize() => Container = new UnityContainer();

        #endregion


        [TestMethod]
        public void Baseline()
        { }

        #region Test Data

        #endregion
    }
}
