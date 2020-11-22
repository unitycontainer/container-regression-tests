using System;


namespace Regression.Implicit.Fields
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => default(TDependency);
    }
}
