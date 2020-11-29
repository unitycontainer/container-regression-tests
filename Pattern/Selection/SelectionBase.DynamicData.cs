using System.Collections.Generic;

namespace Selection
{
    public abstract partial class SelectionBase
    {
        public static IEnumerable<object[]> BasicOperationTests_Data
        {
            get
            {
                foreach (var type in FromNamespace("Basics"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }
    }
}
