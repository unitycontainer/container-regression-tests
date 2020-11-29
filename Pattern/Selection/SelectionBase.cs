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
        protected static Type BaselineTestType;
        protected static Type NoPublicMemberImplicit;
        protected static Type NoPublicMemberRequired;
        protected static Type NoPublicMemberOptional;

        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            FixtureBase.ClassInitialize(context);

            BaselineTestType = GetType("BaselineTestType`2");

            ImplicitType = GetType("Implicit",           "BaselineTestType`2");
            RequiredType = GetType("Annotated", "Required.BaselineTestType`2");
            OptionalType = GetType("Annotated", "Optional.BaselineTestType`2");
            NoPublicMemberImplicit = GetType("Implicit",           "NoPublicMember`1");
            NoPublicMemberRequired = GetType("Annotated", "Required.NoPublicMember`1");
            NoPublicMemberOptional = GetType("Annotated", "Optional.NoPublicMember`1");

            LoadInjectionProxies();
        }

        #endregion
    }
}
