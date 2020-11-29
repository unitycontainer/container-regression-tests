using System;
using static Selection.SelectionBase;

namespace Selection.Implicit.Properties
{
    public class BaselineTestType<TDependency, TDefault>
        : PropertySelectionBase
    {
        public TDependency Property { get => (TDependency)Data[0]; set => Data[0] = value; }

    }

    public class NoPublicMember<TDependency>
    {
        private TDependency Property { get; set; }
    }
}


namespace Selection.Implicit.Properties.EdgeCases
{
    public class DummySelectionImplicit : SelectionBaseType { }
}
