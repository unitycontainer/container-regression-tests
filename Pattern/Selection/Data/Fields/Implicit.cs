using static Selection.SelectionBase;
using System;

namespace Selection.Implicit.Fields
{
    public class BaselineTestType<TDependency, TDefault>
        : SelectionBaseType
    {
        public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class NoPublicMember<TDependency>
    {
        private TDependency Field;
    }
}


namespace Selection.Implicit.Fields.Basics
{
    public class SuccessDummy : SelectionBaseType
    {
    }
}
