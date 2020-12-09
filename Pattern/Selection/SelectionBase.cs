using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;

namespace Selection
{
    public abstract partial class SelectionBase : FixtureBase
    {
        #region Fields

        protected static Type ImplicitType;
        protected static Type RequiredType;
        protected static Type OptionalType;

        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            FixtureBase.ClassInitialize(context);

            ImplicitType = GetType("Implicit",           "BaselineTestType`2");
            RequiredType = GetType("Annotated", "Required.BaselineTestType`2");
            OptionalType = GetType("Annotated", "Optional.BaselineTestType`2");

            LoadInjectionProxies();
        }

        #endregion
    }
}
