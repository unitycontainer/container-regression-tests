using System;


namespace Regression.Implicit.Properties
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Expected => default(TDependency);
    }
}
