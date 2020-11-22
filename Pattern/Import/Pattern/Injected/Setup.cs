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
    }
}
