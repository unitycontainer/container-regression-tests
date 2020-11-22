using System;
using System.Collections.Generic;

namespace Regression.Implicit
{
    public abstract partial class Pattern : PatternBase
    {
        #region Fields

        protected Type TypeDefinition;

        #endregion


        #region Test Data

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
