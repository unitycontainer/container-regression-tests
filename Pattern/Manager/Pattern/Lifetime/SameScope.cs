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
        public virtual void FromSameContainer()
        {
            // Act
            Item1 = Container.Resolve(TargetType);
            Item2 = Container.Resolve(TargetType);

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);
            
            FromSameScope(Item1, Item2);
        }

        [TestMethod]
        public virtual void FromSameAsImport()
        {
            // Act
            Item1 = Container.Resolve<Foo<MockLogger>>().Value;
            Item2 = Container.Resolve<Foo<MockLogger>>().Value;

            // Validate
            Assert.IsNotNull(Item1);
            Assert.IsNotNull(Item2);

            FromSameScope(Item1, Item2);
        }

        [TestMethod]
        public virtual void FromSameOnDifferentThreads()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart((c) => Item1 = Container.Resolve(TargetType)));
            Thread t2 = new Thread(new ParameterizedThreadStart((c) => Item2 = Container.Resolve(TargetType)));

            t1.Start("1");
            t2.Start("2");
            t1.Join();
            t2.Join();

            Assert.IsInstanceOfType(Item1, TargetType);
            Assert.IsInstanceOfType(Item1, TargetType);

            FromSameScopeDifferentThreads(Item1, Item2);
        }
    }
}
