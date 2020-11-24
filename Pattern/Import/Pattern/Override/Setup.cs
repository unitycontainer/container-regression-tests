using System.Collections.Generic;
using System.Linq;

namespace Regression.Override
{
    public abstract partial class Pattern : PatternBase
    {
        #region Fields

        protected virtual string DependencyName => string.Empty;

        #endregion


        #region Test Data

        public static IEnumerable<object[]> Implicit_WithDefaultValueAttribute_Data
        {
            get
            {
                foreach (var type in FromNamespaces("WithDefaultAttribute"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        public static IEnumerable<object[]> Annotated_WithDefaultValueAttribute_Data
        {
            get
            {
                foreach (var type in FromNamespaces("WithDefaults")
                    .Where(t => t.Name.EndsWith("_WithDefaultAttribute")))
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
