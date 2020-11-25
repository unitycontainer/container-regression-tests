using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Import.Implicit
{
    public abstract partial class Pattern : ImportBase
    {
        #region Fields

        private static Type _inherited;
        private static Type _twice;

        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            ImportBase.ClassInitialize(context);

            _inherited  = GetType("BaselineInheritedType`1");
            _twice      = GetType("BaselineInheritedTwice`1");
        }

        #endregion


        #region Defaults

        public static IEnumerable<object[]> WithDefaultValue_Data
        {
            get
            {
                foreach (var type in FromNamespace("WithDefault"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        public static IEnumerable<object[]> WithDefaultAttribute_Data
        {
            get
            {
                foreach (var type in FromNamespace("WithDefaultAttribute"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        public static IEnumerable<object[]> WithDefaultAndAttribute_Data
        {
            get
            {
                foreach (var type in FromNamespace("WithDefaultAndAttribute"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        #endregion
    }
}
