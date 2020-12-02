using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class ImportBase : FixtureBase
    {
        #region Fields

        protected static Type ArrayType;

        
        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            FixtureBase.ClassInitialize(context);

            ArrayType = GetTestType("ArrayTestType`1");

            LoadInjectionProxies();
        }

        #endregion
    }
}
