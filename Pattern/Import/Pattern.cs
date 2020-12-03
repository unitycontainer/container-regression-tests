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
    public abstract partial class Pattern : FixtureBase
    {
        #region Constants

        protected const string Category_BuiltIn = "BuiltIn";
        protected const string Category_Import = "Import";
        protected const string Category_Inject = "Injection";
        protected const string Category_Override = "Override";
        protected const string Category_Parameter = "Parameters";
        protected const string Category_Defaults = "With Defaults";

        #endregion


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
