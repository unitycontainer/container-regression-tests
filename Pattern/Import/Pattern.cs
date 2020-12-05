using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Import
{
    public abstract partial class Pattern : FixtureBase
    {
        #region Constants

        protected const string PARAMETER = "Inject";
        protected const string OVERRIDE  = "Override";

        protected const string CATEGORY_IMPORT  = "Import";
        protected const string CATEGORY_INJECT  = "Injection";
        protected const string CATEGORY_BUILTIN = "BuiltIn";
        protected const string CATEGORY_OVERRIDE = "Override";
        protected const string CATEGORY_DEFAULTS = "With Defaults";

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
