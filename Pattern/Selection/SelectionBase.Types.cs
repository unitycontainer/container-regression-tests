using Regression;
using System.Collections.Generic;

namespace Selection
{
    public abstract partial class SelectionBase
    {
        public abstract class SelectionBaseType : PatternBaseType
        {
            public IList<object[]> Data = new List<object[]> { null, null, null, null, null};
        }


        #region Test Data

        public class NoMembersType { }

        #endregion
    }
}
