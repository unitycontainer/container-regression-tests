using Regression;
using System;
using static Import.ImportBase;


namespace Import.Implicit.Fields
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        public TDependency Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }
}

