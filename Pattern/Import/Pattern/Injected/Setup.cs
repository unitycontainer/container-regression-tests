using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class InjectedPattern : PatternBase
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
