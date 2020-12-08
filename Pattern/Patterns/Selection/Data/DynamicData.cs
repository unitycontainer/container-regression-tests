using System.Collections.Generic;
using System.Linq;


namespace Selection
{
    public abstract partial class Pattern
    {
        #region Test Data

        public static IEnumerable<object[]> EdgeCases_Data
        {
            get
            {
                var types = FromPatternNamespace("EdgeCases").ToArray();
                
                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummySelection) };
            }
        }


        public static IEnumerable<object[]> EdgeCases_Throwing_Data
        {
            get
            {
                var types = FromPatternNamespace("EdgeCasesThrowing").ToArray();

                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(UnresolvableDummySelection) };
            }
        }

        #endregion
    }
}
