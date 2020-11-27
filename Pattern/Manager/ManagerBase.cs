using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Manager
{
    public abstract partial class ManagerBase : FixtureBase
    {
        #region Fields

        protected LifetimeManager LifetimeManager;

        #endregion


        #region Scaffolding

        public override void TestInitialize()
        {
            base.TestInitialize();
            LifetimeManager = GetManager();
        }
        
        protected abstract LifetimeManager GetManager();

        #endregion
    }
}
