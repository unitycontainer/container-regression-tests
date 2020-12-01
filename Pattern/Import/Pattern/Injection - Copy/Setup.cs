using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Injected
{
    public abstract partial class Pattern : ImportBase
    {
        #region Fields

        protected static Type ImplicitArrayType;
        protected static Type RequiredArrayType;
        protected static Type OptionalArrayType;

        protected static Type ImplicitImportType;
        protected static Type RequiredImportType;
        protected static Type OptionalImportType;
        protected static Type RequiredImportNamed;
        protected static Type OptionalImportNamed;

        #endregion





        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            ImportBase.ClassInitialize(context);

            ImplicitArrayType   = GetTestType("Implicit", "ArrayTestType`1");
            RequiredArrayType   = GetTestType("Required", "ArrayTestType`1");
            OptionalArrayType   = GetTestType("Optional", "ArrayTestType`1");

            ImplicitImportType  = GetTestType("Implicit", "BaselineTestType`1");
            RequiredImportType  = GetTestType("Required", "BaselineTestType`1");
            RequiredImportNamed = GetTestType("Required", "BaselineTestTypeNamed`1");
            OptionalImportType  = GetTestType("Optional", "BaselineTestType`1");
            OptionalImportNamed = GetTestType("Optional", "BaselineTestTypeNamed`1");
        }

        #endregion

    }
}
