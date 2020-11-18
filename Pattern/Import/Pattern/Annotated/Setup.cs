using Microsoft.VisualStudio.TestTools.UnitTesting;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class AnnotatedPattern : PatternBase
    {
        [TestMethod]
        public void Baseline()
        {
            var instance = Container.Resolve(typeof(BaselineType), null) as PatternBaseType;

            Assert.IsNotNull(instance);
            Assert.IsNull(instance.Value);
        }
    }
}
