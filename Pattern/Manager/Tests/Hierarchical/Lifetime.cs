using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Registration.Lifetime
{
    [TestClass]
    public class Hierarchical : Regression.Lifetime.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        protected override LifetimeManager GetManager() => new HierarchicalLifetimeManager();

        #endregion


        #region Validation

        public override void FromSameScope(object item1, object item2)
            => Assert.AreSame(Item1, Item2);

        public override void FromChildScope(object item1, object item2)
            => Assert.AreNotSame(Item1, Item2);

        public override void FromSameScopeDifferentThreads(object item1, object item2)
            => Assert.AreSame(Item1, Item2);

        public override void FromChildScopeDifferentThreads(object item1, object item2)
            => Assert.AreNotSame(Item1, Item2);

        #endregion
    }
}
