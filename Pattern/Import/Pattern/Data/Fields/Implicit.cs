using Regression;
using System;
using static Import.ImportBase;


namespace Import.Implicit.Fields
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        public TDependency Field;
        public override object Value { get => Field; }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : ImportBaseType
    {
        public TDependency Field;

        public override object Value { get => Field; }
        public override object Default => default(TDependency);
    }
}

