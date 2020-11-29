using System;
using static Selection.SelectionBase;

namespace Selection.Implicit.Properties
{
    public class BaselineTestType<TDependency, TDefault>
        : SelectionBaseType
    {
        public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class NoPublicMember<TDependency>
    {
        private TDependency Property { get; set; }
    }
}


namespace Selection.Implicit.Properties.Basics
{
    public class SuccessDummy : SelectionBaseType
    {
    }
}
