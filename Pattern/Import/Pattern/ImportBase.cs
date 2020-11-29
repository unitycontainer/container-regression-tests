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

        protected static Type ImplicitImportType;
        protected static Type RequiredImportType;
        protected static Type OptionalImportType;
        protected static Type RequiredImportNamed;
        protected static Type OptionalImportNamed;
        protected static Type ImplicitArrayType;
        protected static Type RequiredArrayType;
        protected static Type OptionalArrayType;
        
        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            FixtureBase.ClassInitialize(context);

            ImplicitImportType  = GetType("Implicit",           "BaselineTestType`1");
            RequiredImportType  = GetType("Annotated", "Required.BaselineTestType`1");
            RequiredImportNamed = GetType("Annotated", "Required.BaselineTestTypeNamed`1");
            OptionalImportType  = GetType("Annotated", "Optional.BaselineTestType`1");
            OptionalImportNamed = GetType("Annotated", "Optional.BaselineTestTypeNamed`1");
            ImplicitArrayType   = GetType("Implicit",           "ArrayTestType`1");
            RequiredArrayType   = GetType("Annotated", "Required.ArrayTestType`1");
            OptionalArrayType   = GetType("Annotated", "Optional.ArrayTestType`1");

            LoadInjectionProxies();
        }

        #endregion
    }
}
