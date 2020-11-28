#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Regression
{
    public abstract partial class ManagerBase : FixtureBase
    {
        #region Fields

        protected object Item1;
        protected object Item2;

        #endregion


        #region Scaffolding

        protected abstract LifetimeManager GetManager();

        #endregion
    }
}
