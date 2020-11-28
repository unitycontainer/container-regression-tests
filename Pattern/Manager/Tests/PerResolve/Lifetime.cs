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
    public class PerResolve : Regression.Lifetime.Pattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            TargetType = typeof(IView);
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        protected override LifetimeManager GetManager() => new PerResolveLifetimeManager();

        #endregion

        
        #region Validation

        public override void FromSameScope(object item1, object item2)
        {
            Assert.AreNotSame(Item1, Item2);
            Assert.AreSame(((IView)Item1).Presenter.View, Item1);
            Assert.AreSame(((IView)Item2).Presenter.View, Item2);
            Assert.AreNotSame(Item1, Item2);
        }

        public override void FromChildScope(object item1, object item2)
        {
            Assert.AreNotSame(Item1, Item2);
            Assert.AreSame(((IView)Item1).Presenter.View, Item1);
            Assert.AreSame(((IView)Item2).Presenter.View, Item2);
            Assert.AreNotSame(Item1, Item2);
        }

        public override void FromSameScopeDifferentThreads(object item1, object item2)
        {
            Assert.AreNotSame(Item1, Item2);
            Assert.AreSame(((IView)Item1).Presenter.View, Item1);
            Assert.AreSame(((IView)Item2).Presenter.View, Item2);
            Assert.AreNotSame(Item1, Item2);
        }

        public override void FromChildScopeDifferentThreads(object item1, object item2)
        {
            Assert.AreNotSame(Item1, Item2);
            Assert.AreSame(((IView)Item1).Presenter.View, Item1);
            Assert.AreSame(((IView)Item2).Presenter.View, Item2);
            Assert.AreNotSame(Item1, Item2);
        }

        #endregion


        #region Inapplicable Tests

        public override void FromSameAsImport() { }
        public override void FromChildAsImport() { }

        #endregion
    }
}
