using Regression;
using System;
using static Import.ImportBase;


namespace Import.Implicit.Properties
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        public TDependency Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }
}
