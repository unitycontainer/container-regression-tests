using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Registration
{
    public abstract partial class Pattern : ManagerBase
    {
    }
}
