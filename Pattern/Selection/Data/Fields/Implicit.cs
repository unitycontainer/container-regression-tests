using static Selection.SelectionBase;
using System;

namespace Selection.Implicit.Fields
{
    public class BaselineTestType<TDependency, TDefault>
        : FieldSelectionBase
    {
        public TDependency Field;

    }

    public class NoPublicMember<TDependency>
    {
        private TDependency Field;
    }
}


namespace Selection.Implicit.Fields.EdgeCases
{
    public class DummySelectionImplicit : SelectionBaseType { }
}
