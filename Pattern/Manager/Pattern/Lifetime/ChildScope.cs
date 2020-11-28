using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Regression.Lifetime
{
    public abstract partial class Pattern
    {
        [TestMethod]
        public virtual void FromChildContainer()
        {
            // Act
            Item1 = Container.Resolve(TargetType);
            Item2 = Container.CreateChildContainer()
                             .Resolve(TargetType);

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);
        
            FromChildScope(Item1, Item2);
        }

        [TestMethod]
        public virtual void FromChildAsImport()
        {
            // Act
            Item1 = Container.Resolve<Foo<MockLogger>>().Value;
            Item2 = Container.CreateChildContainer()
                             .Resolve<Foo<MockLogger>>().Value;

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            FromChildScope(Item1, Item2);
        }

        [TestMethod]
        public virtual void FromChildOnDifferentThreads()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart((c) => Item1 = Container.Resolve(TargetType)));
            Thread t2 = new Thread(new ParameterizedThreadStart((c) => Item2 = Container.CreateChildContainer()
                                                                                        .Resolve(TargetType)));
            t1.Start("1");
            t2.Start("2");
            t1.Join();
            t2.Join();

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);

            FromChildScopeDifferentThreads(Item1, Item2);
        }
    }
}
