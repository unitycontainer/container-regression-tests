using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Registration
{
    public partial class Factory
    {
        [TestMethod]
        public void FactoryOpenGeneric()
        {
            // Arrange
            Container.RegisterFactory(typeof(IFoo<>), (c, t, n) => new Foo<object>());

            // Act
            var result = Container.Resolve(typeof(IFoo<object>));

            // Verify
            Assert.IsNotNull(result);
        }
    }
}
