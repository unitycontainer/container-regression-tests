using System.Collections.Generic;

namespace Selection
{
    public abstract partial class SelectionBase
    {
        #region Test Data

        public static IEnumerable<object[]> EdgeCases_Data
        {
            get
            {
                foreach (var type in FromPatternNamespace("EdgeCases"))
                {
                    yield return new object[] { type.Name, type };
                }
            }
        }

        #endregion
    }
}
