using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Registration.Synchronization
{
    [TestClass]
    public class Hierarchical : Manager.Synchronized.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        protected override LifetimeManager GetManager() => new HierarchicalLifetimeManager();

        #endregion

        [TestMethod]
        public void Baseline() { }
    }
}
