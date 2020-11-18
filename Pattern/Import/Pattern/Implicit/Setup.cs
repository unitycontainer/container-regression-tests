using Microsoft.VisualStudio.TestTools.UnitTesting;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class ImplicitPattern : PatternBase
    {
        [TestMethod]
        public void Baseline()
        {
            var type = GetType("BaselineTestType");
            var instance = Container.Resolve(type, null) as PatternBaseType;

            Assert.IsNotNull(instance);
            Assert.IsNull(instance.Value);
        }
    }
}
