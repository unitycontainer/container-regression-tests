using System.Collections.Generic;
using System.Reflection;

namespace Selection
{
    public abstract partial class Pattern
    {
        public static IEnumerable<object[]> Test_Types_Data
        {
            get
            {
                var set = MethodBase.GetCurrentMethod().DeclaringType.Namespace.Split('.')[0];
                foreach (var annotation in Annotation_Category_Names)
                {
                    var type = GetTestType("BaselineTestType`2", annotation, Member, set);

                    yield return new object[] { type.Name, type };
                }
            }
        }
    }
}
