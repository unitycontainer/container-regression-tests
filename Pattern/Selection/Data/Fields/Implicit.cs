using static Selection.SelectionBase;
using System;

namespace Selection.Implicit.Fields
{
    public class BaselineTestType<TItem1, TItem2>
        : FieldSelectionBase
    {
        public TItem1 Field1;
        public TItem2 Field2;
    }
}
